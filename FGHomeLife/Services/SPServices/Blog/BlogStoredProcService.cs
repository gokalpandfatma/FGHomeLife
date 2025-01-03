using Dapper;
using FGHomeLife.Models.DTOs;
using FGHomeLife.Models.ViewModels;
using Microsoft.Data.SqlClient;
using System.Data;

namespace FGHomeLife.Services.SPServices.Blog
{
    public class BlogStoredProcService : IBlogStoredProcService
    {
        private readonly string _connectionString;

        public BlogStoredProcService(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("DefaultConnection");
        }

        public async Task<BlogListViewModel> GetBlogListWithSPAsync(int page = 1, int pageSize = 6, string category = null, string tag = null)
        {
            using var connection = new SqlConnection(_connectionString);
            await connection.OpenAsync();

            using var multi = await connection.QueryMultipleAsync(
                "sp_GetBlogList",
                new { PageNumber = page, PageSize = pageSize, Category = category, Tag = tag },
                commandType: CommandType.StoredProcedure);

            // Blog posts
            var blogPosts = (await multi.ReadAsync<BlogListDTO>()).AsList();
            var posts = blogPosts.Select(p => new Models.ViewModels.BlogPostViewModel
            {
                Id = p.Id,
                Title = p.Title,
                Slug = p.Slug,
                Summary = p.Summary,
                ImageUrl = p.ImageUrl,
                CategoryName = p.CategoryName,
                CategorySlug = p.CategorySlug,
                CommentCount = p.CommentCount,
                Tags = p.Tags?.Split(',').ToList() ?? new List<string>(),
                CreatedAt = p.CreatedAt
            }).AsList();

            // Categories
            var categories = (await multi.ReadAsync<BlogCategoryViewModel>()).AsList();

            // Tags
            var tags = (await multi.ReadAsync<BlogTagViewModel>()).AsList();

            // Total pages calculation
            var totalPosts = blogPosts.FirstOrDefault()?.TotalCount ?? 0;
            var totalPages = (int)Math.Ceiling(totalPosts / (double)pageSize);

            return new BlogListViewModel
            {
                Posts = posts,
                Categories = categories,
                PopularTags = tags,
                Pagination = new PaginationViewModel
                {
                    CurrentPage = page,
                    TotalPages = totalPages
                }
            };
        }
    }
}
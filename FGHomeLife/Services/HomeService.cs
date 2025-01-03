using Microsoft.EntityFrameworkCore;
using FGHomeLife.Data;
using FGHomeLife.Models;
using FGHomeLife.Models.ViewModels;
using FGHomeLife.Services.Interfaces;

namespace FGHomeLife.Services
{
    public class HomeService : IHomeService
    {
        private readonly FGAppDbContext _context;

        public HomeService(FGAppDbContext context)
        {
            _context = context;
        }

        public async Task<HomeViewModel> GetHomePageDataAsync()
        {
            return new HomeViewModel
            {
                Categories = await GetCategoriesAsync(),
                FeaturedProducts = await GetFeaturedProductsAsync(),
                //RecentBlogPosts = await GetRecentBlogPostsAsync()
            };
        }

        private async Task<List<CategoryViewModel>> GetCategoriesAsync()
        {
            return await _context.Categories
                .Where(c => c.IsActive)
                .Select(c => new CategoryViewModel
                {
                    Id = c.Id,
                    Name = c.Name,
                    Description = c.Description,
                    IconClass = c.IconClass
                })
                .ToListAsync();
        }

        private async Task<List<ProductViewModel>> GetFeaturedProductsAsync()
        {
            return await _context.Products
                .Where(p => p.IsActive)
                .OrderByDescending(p => p.CreatedAt)
                .Take(6)
                .Select(p => new ProductViewModel
                {
                    Id = p.Id,
                    Name = p.Name,
                    Description = p.Description,
                    Price = p.Price,
                    ImageUrl = p.ImageUrl,
                    IsNew = p.IsNew
                })
                .ToListAsync();
        }

        private async Task<List<BlogPostViewModel>> GetRecentBlogPostsAsync()
        {
            return await _context.BlogPosts
                .Where(p => p.IsActive)
                .OrderByDescending(p => p.CreatedAt)
                .Take(3)
                .Select(p => new BlogPostViewModel
                {
                    Id = p.Id,
                    Title = p.Title,
                    Summary = p.Summary,
                    Slug = p.Slug,
                    ImageUrl = p.ImageUrl,
                    CreatedAt = p.CreatedAt,
                    CategoryName = p.Category.Name,
                    CategorySlug = p.Category.Slug,
                    Tags = p.Tags.Select(t => t.Name).ToList(),
                    CommentCount = p.Comments.Count
                })
                .ToListAsync();
        }
    }
}
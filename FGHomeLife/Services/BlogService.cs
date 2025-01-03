using Microsoft.EntityFrameworkCore;
using FGHomeLife.Data;
using FGHomeLife.Models;
using FGHomeLife.Models.ViewModels;
using FGHomeLife.Services.Interfaces;

namespace FGHomeLife.Services
{
    public class BlogService : IBlogService
    {
        private readonly FGAppDbContext _context;

        public BlogService(FGAppDbContext context)
        {
            _context = context;
        }

        public async Task<BlogListViewModel> GetBlogListAsync(int page = 1, int pageSize = 6, string category = null, string tag = null)
        {
            var query = _context.BlogPosts
                .Include(p => p.Category)
                .Include(p => p.Tags)
                .Include(p => p.Comments)
                .Where(p => p.IsActive);

            if (!string.IsNullOrEmpty(category))
            {
                query = query.Where(p => p.Category.Slug == category);
            }

            if (!string.IsNullOrEmpty(tag))
            {
                query = query.Where(p => p.Tags.Any(t => t.Slug == tag));
            }

            var totalPosts = await query.CountAsync();
            var totalPages = (int)Math.Ceiling(totalPosts / (double)pageSize);

            var posts = await query
                .OrderByDescending(p => p.CreatedAt)
                .Skip((page - 1) * pageSize)
                .Take(pageSize)
                .Select(p => new BlogPostViewModel
                {
                    Id = p.Id,
                    Title = p.Title,
                    Slug = p.Slug,
                    Summary = p.Summary,
                    ImageUrl = p.ImageUrl,
                    CategoryName = p.Category.Name,
                    CategorySlug = p.Category.Slug,
                    Tags = p.Tags.Select(t => t.Name).ToList(),
                    CommentCount = p.Comments.Count,
                    CreatedAt = p.CreatedAt
                })
                .ToListAsync();

            return new BlogListViewModel
            {
                //Posts = posts,
                Categories = await GetCategoriesAsync(),
                PopularTags = await GetPopularTagsAsync(),
                Pagination = new PaginationViewModel
                {
                    CurrentPage = page,
                    TotalPages = totalPages
                }
            };
        }

        public async Task<List<BlogCategoryViewModel>> GetCategoriesAsync()
        {
            return await _context.BlogCategories
                .Where(c => c.IsActive)
                .Select(c => new BlogCategoryViewModel
                {
                    Name = c.Name,
                    Slug = c.Slug,
                    PostCount = c.BlogPosts.Count(p => p.IsActive)
                })
                .ToListAsync();
        }

        public async Task<List<BlogTagViewModel>> GetPopularTagsAsync(int take = 10)
        {
            return await _context.BlogTags
                .Select(t => new BlogTagViewModel
                {
                    Name = t.Name,
                    Slug = t.Slug,
                    PostCount = t.BlogPosts.Count(p => p.IsActive)
                })
                .OrderByDescending(t => t.PostCount)
                .Take(take)
                .ToListAsync();
        }

        public async Task<BlogDetailViewModel> GetBlogDetailAsync(string slug)
        {
            var post = await _context.BlogPosts
                .Include(p => p.Category)
                .Include(p => p.Tags)
                .Include(p => p.Comments)
                    .ThenInclude(c => c.User)
                .Include(p => p.Comments)
                    .ThenInclude(c => c.Replies)
                        .ThenInclude(r => r.User)
                .FirstOrDefaultAsync(p => p.Slug == slug && p.IsActive);

            if (post == null) return null;

            // Görüntülenme sayısını artır
            post.ViewCount++;
            await _context.SaveChangesAsync();

            return new BlogDetailViewModel
            {
                Id = post.Id,
                Title = post.Title,
                Content = post.Content,
                ImageUrl = post.ImageUrl,
                CategoryName = post.Category.Name,
                CategorySlug = post.Category.Slug,
                Tags = post.Tags.Select(t => t.Name).ToList(),
                CreatedAt = post.CreatedAt,
                Comments = await GetCommentsForPost(post.Id),
                //RelatedPosts = await GetRelatedPosts(post.Id, post.CategoryId)
            };
        }

        private async Task<List<BlogCommentViewModel>> GetCommentsForPost(int postId)
        {
            return await _context.BlogComments
                .Include(c => c.User)
                .Include(c => c.Replies)
                    .ThenInclude(r => r.User)
                .Where(c => c.BlogPostId == postId && c.ParentCommentId == null && c.IsApproved)
                .OrderByDescending(c => c.CreatedAt)
                .Select(c => new BlogCommentViewModel
                {
                    Id = c.Id,
                    UserName = c.User.Name,
                    Content = c.Content,
                    CreatedAt = c.CreatedAt,
                    Replies = c.Replies
                        .Where(r => r.IsApproved)
                        .OrderBy(r => r.CreatedAt)
                        .Select(r => new BlogCommentViewModel
                        {
                            Id = r.Id,
                            UserName = r.User.Name,
                            Content = r.Content,
                            CreatedAt = r.CreatedAt
                        }).ToList()
                })
                .ToListAsync();
        }

        private async Task<List<BlogPostViewModel>> GetRelatedPosts(int currentPostId, int categoryId)
        {
            return await _context.BlogPosts
                .Where(p => p.Id != currentPostId && p.CategoryId == categoryId && p.IsActive)
                .OrderByDescending(p => p.CreatedAt)
                .Take(3)
                .Select(p => new BlogPostViewModel
                {
                    Id = p.Id,
                    Title = p.Title,
                    Slug = p.Slug,
                    ImageUrl = p.ImageUrl,
                    CreatedAt = p.CreatedAt
                })
                .ToListAsync();
        }

        public async Task<bool> AddCommentAsync(int postId, int userId, string content, int? parentCommentId = null)
        {
            try
            {
                var comment = new BlogComment
                {
                    BlogPostId = postId,
                    UserId = userId,
                    ParentCommentId = parentCommentId,
                    Content = content,
                    IsApproved = true, // Otomatik onay. İsterseniz false yapıp admin onayına sunabilirsiniz
                    CreatedAt = DateTime.Now
                };

                _context.BlogComments.Add(comment);
                await _context.SaveChangesAsync();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public async Task<int> GetTotalPostCountAsync(string category = null, string tag = null)
        {
            var query = _context.BlogPosts.Where(p => p.IsActive);

            if (!string.IsNullOrEmpty(category))
            {
                query = query.Where(p => p.Category.Slug == category);
            }

            if (!string.IsNullOrEmpty(tag))
            {
                query = query.Where(p => p.Tags.Any(t => t.Slug == tag));
            }

            return await query.CountAsync();
        }
    }
}
using FGHomeLife.Models.ViewModels;

namespace FGHomeLife.Services.EFServices.Blog
{
    public interface IBlogService
    {
        Task<BlogListViewModel> GetBlogListAsync(int page = 1, int pageSize = 6, string category = null, string tag = null);
        Task<BlogDetailViewModel> GetBlogDetailAsync(string slug);
        Task<List<BlogCategoryViewModel>> GetCategoriesAsync();
        Task<List<BlogTagViewModel>> GetPopularTagsAsync(int take = 10);
        Task<bool> AddCommentAsync(int postId, int userId, string content, int? parentCommentId = null);
        Task<int> GetTotalPostCountAsync(string category = null, string tag = null);
    }
}
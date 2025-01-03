using FGHomeLife.Models.ViewModels;

namespace FGHomeLife.Services.Interfaces
{
    public interface IBlogStoredProcService
    {
        Task<BlogListViewModel> GetBlogListWithSPAsync(int page = 1, int pageSize = 6, string category = null, string tag = null);
    }
}
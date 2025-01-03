using Microsoft.AspNetCore.Mvc;
using FGHomeLife.Models.ViewModels;
using FGHomeLife.Services.SPServices.Blog;
using FGHomeLife.Services.EFServices.Blog;

namespace FGHomeLife.Controllers
{
    public class BlogController : Controller
    {
        private readonly IBlogService _blogService;
        private readonly IBlogStoredProcService _blogStoredProcService;

        public BlogController(IBlogService blogService, IBlogStoredProcService blogStoredProcService)
        {
            _blogService = blogService;
            _blogStoredProcService = blogStoredProcService;
        }

        public async Task<IActionResult> Index(int page = 1, string category = null, string tag = null)
        {
            // Entity Framework ile
            var model = await _blogService.GetBlogListAsync(page, 6, category, tag);

            // Stored Procedure ile
            //var model = await _blogStoredProcService.GetBlogListWithSPAsync(page, 6, category, tag);

            return View(model);
        }
    }
}
using Microsoft.AspNetCore.Mvc;
using FGHomeLife.Services.Interfaces;
using FGHomeLife.Models.ViewModels;

namespace FGHomeLife.Controllers
{
    public class BlogController : Controller
    {
        private readonly IBlogService _blogService;

        public BlogController(IBlogService blogService)
        {
            _blogService = blogService;
        }

        public async Task<IActionResult> Index(int page = 1, string category = null, string tag = null)
        {
            var model = await _blogService.GetBlogListAsync(page, 6, category, tag);
            return View(model);
        }
    }
}
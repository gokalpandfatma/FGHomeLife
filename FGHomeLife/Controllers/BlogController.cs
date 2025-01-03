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

        // Blog Listesi
        public async Task<IActionResult> Index(int page = 1, string category = null, string tag = null)
        {
            var model = await _blogService.GetBlogListAsync(page, 6, category, tag);
            return View(model);
        }

        // Blog Detay
        public async Task<IActionResult> Detail(string slug)
        {
            var model = await _blogService.GetBlogDetailAsync(slug);
            if (model == null)
                return NotFound();

            return View(model);
        }

        // Yorum Ekleme (AJAX için)
        [HttpPost]
        public async Task<IActionResult> AddComment(int postId, string content, int? parentCommentId)
        {
            // TODO: Gerçek kullanıcı ID'sini alacağız
            int userId = 1; // Şimdilik sabit

            var result = await _blogService.AddCommentAsync(postId, userId, content, parentCommentId);

            if (result)
                return Json(new { success = true });

            return Json(new { success = false, message = "Yorum eklenirken bir hata oluştu." });
        }
    }
}
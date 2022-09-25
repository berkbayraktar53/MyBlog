using Business.Abstract;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace WebUI.Controllers
{
    [AllowAnonymous]
    public class BlogController : Controller
    {
        private readonly IBlogService _blogService;

        public BlogController(IBlogService blogService)
        {
            _blogService = blogService;
        }

        public IActionResult Index()
        {
            var values = _blogService.GetListWithCategory();
            return View(values);
        }

        public IActionResult Detail(int id)
        {
            @ViewBag.commentId = id;
            var values = _blogService.GetListById(id);
            return View(values);
        }
    }
}
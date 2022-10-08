using Business.Abstract;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace WebUI.Controllers
{
    [AllowAnonymous]
    public class WriterController : Controller
    {
        private readonly IBlogService _blogService;
        private readonly ICategoryService _categoryService;

        public WriterController(IBlogService blogService, ICategoryService categoryService)
        {
            _blogService = blogService;
            _categoryService = categoryService;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Dashboard()
        {
            ViewBag.TotalBlog = _blogService.GetList().Count;
            ViewBag.TotalBlogByWriter = _blogService.GetListByWriter(1).Count;
            ViewBag.TotalCategory = _categoryService.GetList().Count;
            return View();
        }

        public IActionResult Profile()
        {
            return View();
        }
    }
}
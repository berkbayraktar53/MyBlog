using Business.Abstract;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace WebUI.Controllers
{
    public class HomeController : Controller
    {
        private readonly IBlogService _blogService;

        public HomeController(IBlogService blogService)
        {
            _blogService = blogService;
        }

        [AllowAnonymous]
        public IActionResult Index()
        {
            var values = _blogService.GetListWithCategory();
            return View(values);
        }
    }
}
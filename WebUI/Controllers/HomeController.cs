using Business.Abstract;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using X.PagedList;

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
        public IActionResult Index(int page = 1)
        {
            var values = _blogService.GetListWithCategory().ToPagedList(page, 12);
            return View(values);
        }
    }
}
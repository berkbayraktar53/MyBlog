using Business.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace WebUI.ViewComponents.Blog
{
    public class BlogLast3Post : ViewComponent
    {
        private readonly IBlogService _blogService;

        public BlogLast3Post(IBlogService blogService)
        {
            _blogService = blogService;
        }

        public IViewComponentResult Invoke()
        {
            var result = _blogService.GetLast3Blog();
            return View(result);
        }
    }
}
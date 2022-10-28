using Business.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace WebUI.ViewComponents.Blog
{
    public class BlogListByMostRead : ViewComponent
    {
        private readonly IBlogService _blogService;

        public BlogListByMostRead(IBlogService blogService)
        {
            _blogService = blogService;
        }

        public IViewComponentResult Invoke()
        {
            var result = _blogService.GetListByMostRead();
            return View(result);
        }
    }
}
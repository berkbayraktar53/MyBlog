using Business.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace WebUI.ViewComponents.Blog
{
    public class WriterLastBlog : ViewComponent
    {
        private readonly IBlogService _blogService;

        public WriterLastBlog(IBlogService blogService)
        {
            _blogService = blogService;
        }

        public IViewComponentResult Invoke()
        {
            var result = _blogService.GetListByWriter(1);
            return View(result);
        }
    }
}
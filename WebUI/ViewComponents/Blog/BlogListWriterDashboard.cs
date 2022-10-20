using Business.Abstract;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace WebUI.ViewComponents.Blog
{
    public class BlogListWriterDashboard : ViewComponent
    {
        private readonly IBlogService _blogService;

        public BlogListWriterDashboard(IBlogService blogService)
        {
            _blogService = blogService;
        }

        public IViewComponentResult Invoke()
        {
            var result = _blogService.GetListWithCategory();
            return View(result);
        }
    }
}
using Business.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace WebUI.ViewComponents.Blog
{
    public class BlogAddComment : ViewComponent
    {
        private readonly IBlogService _blogService;

        public BlogAddComment(IBlogService blogService)
        {
            _blogService = blogService;
        }

        public IViewComponentResult Invoke(int blogId)
        {
            var result = _blogService.GetById(blogId);
            return View(result);
        }
    }
}
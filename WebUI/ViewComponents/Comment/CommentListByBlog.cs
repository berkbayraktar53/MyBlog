using Business.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace WebUI.ViewComponents.Comment
{
    public class CommentListByBlog : ViewComponent
    {
        private readonly ICommentService _commentService;

        public CommentListByBlog(ICommentService commentService)
        {
            _commentService = commentService;
        }

        public IViewComponentResult Invoke(int id)
        {
            var values = _commentService.GetListByBlog(id);
            return View(values);
        }
    }
}
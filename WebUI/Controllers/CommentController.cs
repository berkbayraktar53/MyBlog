using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Mvc;
using System;

namespace WebUI.Controllers
{
    public class CommentController : Controller
    {
        private readonly ICommentService _commentService;

        public CommentController(ICommentService commentService)
        {
            _commentService = commentService;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public PartialViewResult AddComment()
        {
            return PartialView();
        }

        [HttpPost]
        public IActionResult AddComment(Comment comment)
        {
            comment.Date = DateTime.Parse(DateTime.Now.ToShortDateString());
            comment.Status = true;
            comment.BlogId = 2;
            _commentService.Add(comment);
            return RedirectToAction("Index", "Blog");
        }
    }
}
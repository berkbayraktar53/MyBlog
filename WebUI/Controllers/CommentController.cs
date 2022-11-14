using AspNetCoreHero.ToastNotification.Abstractions;
using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;

namespace WebUI.Controllers
{
    [AllowAnonymous]
    public class CommentController : Controller
    {
        private readonly ICommentService _commentService;
        private readonly INotyfService _notyfService;

        public CommentController(ICommentService commentService, INotyfService notyfService)
        {
            _commentService = commentService;
            _notyfService = notyfService;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public PartialViewResult AddComment(int blogId)
        {
            ViewBag.id = blogId;
            return PartialView();
        }

        [HttpPost]
        public IActionResult AddComment(Comment comment)
        {
            comment.AddedDate = DateTime.Now;
            comment.Status = true;
            _commentService.Add(comment);
            _notyfService.Success("Yorumunuz eklendi");
            return RedirectToAction("Index", "Home");
        }
    }
}
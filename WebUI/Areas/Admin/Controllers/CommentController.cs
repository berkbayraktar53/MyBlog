using System;
using System.Linq;
using Business.Abstract;
using Entities.Concrete;
using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.Rendering;
using Business.ValidationRules.FluentValidation;
using AspNetCoreHero.ToastNotification.Abstractions;

namespace WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class CommentController : Controller
    {
        private readonly IBlogService _blogService;
        private readonly ICommentService _commentService;
        private readonly INotyfService _notyfService;
        public CommentController(IBlogService blogService, ICommentService commentService, INotyfService notyfService)
        {
            _blogService = blogService;
            _commentService = commentService;
            _notyfService = notyfService;
        }

        public IActionResult Index()
        {
            var values = _commentService.GetListWithBlog();
            return View(values);
        }

        [HttpGet]
        public IActionResult Add()
        {
            List<SelectListItem> blogValues = (from x in _blogService.GetListByActiveStatus()
                                               select new SelectListItem
                                               {
                                                   Text = x.Title,
                                                   Value = x.BlogId.ToString()
                                               }).ToList();
            ViewBag.blogs = blogValues;
            return View();
        }

        [HttpPost]
        public IActionResult Add(Comment comment)
        {
            CommentValidator commentValidator = new();
            ValidationResult validationResult = commentValidator.Validate(comment);
            if (validationResult.IsValid)
            {
                comment.AddedDate = DateTime.Now;
                comment.Status = true;
                _commentService.Add(comment);
                _notyfService.Success("Yorum Eklendi");
                return RedirectToAction("Index", "Comment");
            }
            else
            {
                List<SelectListItem> blogValues = (from x in _blogService.GetListByActiveStatus()
                                                   select new SelectListItem
                                                   {
                                                       Text = x.Title,
                                                       Value = x.BlogId.ToString()
                                                   }).ToList();
                ViewBag.blogs = blogValues;
                foreach (var item in validationResult.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
                _notyfService.Error("Yorum Eklenemedi");
                return View(comment);
            }
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            List<SelectListItem> blogValues = (from x in _blogService.GetListByActiveStatus()
                                               select new SelectListItem
                                               {
                                                   Text = x.Title,
                                                   Value = x.BlogId.ToString()
                                               }).ToList();
            ViewBag.blogs = blogValues;
            var values = _commentService.GetById(id);
            return View(values);
        }

        [HttpPost]
        public IActionResult Edit(Comment comment)
        {
            CommentValidator commentValidator = new();
            ValidationResult validationResult = commentValidator.Validate(comment);
            if (validationResult.IsValid)
            {
                comment.AddedDate = DateTime.Now;
                comment.Status = true;
                _commentService.Update(comment);
                _notyfService.Success("Yorum Güncellendi");
                return RedirectToAction("Index", "Comment");
            }
            else
            {
                List<SelectListItem> blogValues = (from x in _blogService.GetListByActiveStatus()
                                                   select new SelectListItem
                                                   {
                                                       Text = x.Title,
                                                       Value = x.BlogId.ToString()
                                                   }).ToList();
                ViewBag.blogs = blogValues;
                foreach (var item in validationResult.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
                _notyfService.Error("Yorum Güncellenemedi");
                return View(comment);
            }
        }

        public IActionResult Delete(int id)
        {
            var values = _commentService.GetById(id);
            _commentService.Delete(values);
            _notyfService.Success("Yorum Silindi");
            return RedirectToAction("Index", "Comment");
        }

        public IActionResult ChangeStatus(int id)
        {
            var values = _commentService.GetById(id);
            if (values.Status == true)
            {
                values.Status = false;
            }
            else
            {
                values.Status = true;
            }
            _commentService.Update(values);
            _notyfService.Success("Durum Değiştirildi");
            return RedirectToAction("Index", "Comment");
        }
    }
}
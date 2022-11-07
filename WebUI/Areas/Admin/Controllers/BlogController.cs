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
    public class BlogController : Controller
    {
        private readonly IBlogService _blogService;
        private readonly ICategoryService _categoryService;
        private readonly INotyfService _notyfService;
        private readonly IUserService _userService;

        public BlogController(IBlogService blogService, ICategoryService categoryService, INotyfService notyfService, IUserService userService)
        {
            _blogService = blogService;
            _categoryService = categoryService;
            _notyfService = notyfService;
            _userService = userService;
        }
        public IActionResult Index()
        {
            var values = _blogService.GetListWithCategoryAndUser();
            return View(values);
        }

        [HttpGet]
        public IActionResult Add()
        {
            List<SelectListItem> categoryValues = (from x in _categoryService.GetListByActiveStatus()
                                                   select new SelectListItem
                                                   {
                                                       Text = x.CategoryName,
                                                       Value = x.CategoryId.ToString()
                                                   }).ToList();
            List<SelectListItem> userValues = (from x in _userService.GetList()
                                               select new SelectListItem
                                               {
                                                   Text = x.NameSurname,
                                                   Value = x.Id.ToString()
                                               }).ToList();
            ViewBag.categories = categoryValues;
            ViewBag.users = userValues;
            return View();
        }

        [HttpPost]
        public IActionResult Add(Blog blog)
        {
            BlogValidator blogValidator = new();
            ValidationResult validationResult = blogValidator.Validate(blog);
            if (validationResult.IsValid)
            {
                blog.AddedDate = DateTime.Now;
                blog.ModifiedDate = DateTime.Now;
                blog.Status = true;
                _blogService.Add(blog);
                _notyfService.Success("Blog Eklendi");
                return RedirectToAction("Index", "Blog");
            }
            else
            {
                List<SelectListItem> categoryValues = (from x in _categoryService.GetListByActiveStatus()
                                                       select new SelectListItem
                                                       {
                                                           Text = x.CategoryName,
                                                           Value = x.CategoryId.ToString()
                                                       }).ToList();
                List<SelectListItem> userValues = (from x in _userService.GetList()
                                                   select new SelectListItem
                                                   {
                                                       Text = x.NameSurname,
                                                       Value = x.Id.ToString()
                                                   }).ToList();
                ViewBag.categories = categoryValues;
                ViewBag.users = userValues;
                foreach (var item in validationResult.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
                _notyfService.Error("Blog Eklenemedi");
                return View(blog);
            }
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            List<SelectListItem> categoryValues = (from x in _categoryService.GetListByActiveStatus()
                                                   select new SelectListItem
                                                   {
                                                       Text = x.CategoryName,
                                                       Value = x.CategoryId.ToString()
                                                   }).ToList();
            List<SelectListItem> userValues = (from x in _userService.GetList()
                                               select new SelectListItem
                                               {
                                                   Text = x.NameSurname,
                                                   Value = x.Id.ToString()
                                               }).ToList();
            ViewBag.categories = categoryValues;
            ViewBag.users = userValues;
            var values = _blogService.GetById(id);
            return View(values);
        }

        [HttpPost]
        public IActionResult Edit(Blog blog)
        {
            BlogValidator blogValidator = new();
            ValidationResult validationResult = blogValidator.Validate(blog);
            if (validationResult.IsValid)
            {
                blog.ModifiedDate = DateTime.Now;
                blog.Status = true;
                _blogService.Update(blog);
                _notyfService.Success("Blog Güncellendi");
                return RedirectToAction("Index", "Blog");
            }
            else
            {
                List<SelectListItem> categoryValues = (from x in _categoryService.GetListByActiveStatus()
                                                       select new SelectListItem
                                                       {
                                                           Text = x.CategoryName,
                                                           Value = x.CategoryId.ToString()
                                                       }).ToList();
                List<SelectListItem> userValues = (from x in _userService.GetList()
                                                   select new SelectListItem
                                                   {
                                                       Text = x.NameSurname,
                                                       Value = x.Id.ToString()
                                                   }).ToList();
                ViewBag.categories = categoryValues;
                ViewBag.users = userValues;
                foreach (var item in validationResult.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
                _notyfService.Error("Blog Güncellenemedi");
                return View(blog);
            }
        }

        public IActionResult Delete(int id)
        {
            var values = _blogService.GetById(id);
            _blogService.Delete(values);
            _notyfService.Success("Blog Silindi");
            return RedirectToAction("Index", "Blog");
        }

        public IActionResult ChangeStatus(int id)
        {
            var values = _blogService.GetById(id);
            if (values.Status == true)
            {
                values.Status = false;
            }
            else
            {
                values.Status = true;
            }
            _blogService.Update(values);
            _notyfService.Success("Durum Değiştirildi");
            return RedirectToAction("Index", "Blog");
        }
    }
}
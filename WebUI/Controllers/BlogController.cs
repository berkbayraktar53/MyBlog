using AspNetCoreHero.ToastNotification.Abstractions;
using Business.Abstract;
using Business.ValidationRules.FluentValidation;
using Entities.Concrete;
using FluentValidation.Results;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using X.PagedList;

namespace WebUI.Controllers
{
    public class BlogController : Controller
    {
        private readonly UserManager<User> _userManager;
        private readonly IBlogService _blogService;
        private readonly ICategoryService _categoryService;
        private readonly INotyfService _notyfService;
        private readonly IUserService _userService;

        public BlogController(UserManager<User> userManager, IBlogService blogService, ICategoryService categoryService, IUserService userService, INotyfService notyfService)
        {
            _userManager = userManager;
            _blogService = blogService;
            _categoryService = categoryService;
            _notyfService = notyfService;
            _userService = userService;
        }

        [AllowAnonymous]
        public IActionResult Index(int page = 1)
        {
            var values = _blogService.GetListWithCategoryAndComment().ToPagedList(page, 12);
            return View(values);
        }

        [AllowAnonymous]
        public IActionResult Detail(int id)
        {
            @ViewBag.commentId = id;
            var blogStatus = _blogService.GetById(id).Status;
            if (blogStatus == false)
            {
                return RedirectToAction("Error404", "ErrorPage");
            }
            var values = _blogService.GetListById(id);
            return View(values);
        }

        public IActionResult BlogListByWriter()
        {
            var userId = _userManager.FindByNameAsync(User.Identity.Name).Result.Id;
            var values = _blogService.GetListWithCategoryByUser(userId);
            return View(values);
        }

        [HttpGet]
        public IActionResult Add()
        {
            List<SelectListItem> categoryValues = (from x in _categoryService.GetList()
                                                   select new SelectListItem
                                                   {
                                                       Text = x.CategoryName,
                                                       Value = x.CategoryId.ToString()
                                                   }).ToList();
            ViewBag.category = categoryValues;
            return View();
        }

        [HttpPost]
        public IActionResult Add(Blog blog)
        {
            BlogValidator blogValidator = new();
            ValidationResult result = blogValidator.Validate(blog);
            if (result.IsValid)
            {
                var userId = _userManager.FindByNameAsync(User.Identity.Name).Result.Id;
                blog.AddedDate = DateTime.Now;
                blog.Status = true;
                blog.UserId = userId;
                _blogService.Add(blog);
                _notyfService.Success("Blog Eklendi");
                return RedirectToAction("BlogListByWriter", "Blog");
            }
            else
            {
                List<SelectListItem> categoryValues = (from x in _categoryService.GetList()
                                                       select new SelectListItem
                                                       {
                                                           Text = x.CategoryName,
                                                           Value = x.CategoryId.ToString()
                                                       }).ToList();
                ViewBag.category = categoryValues;
                foreach (var item in result.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
                _notyfService.Error("Blog Eklenemedi");
                return View();
            }
        }

        public IActionResult Delete(int id)
        {
            var values = _blogService.GetById(id);
            values.Status = false;
            _blogService.Update(values);
            _notyfService.Success("Blog Silindi");
            return RedirectToAction("BlogListByWriter");
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var values = _blogService.GetById(id);
            List<SelectListItem> categoryValues = (from x in _categoryService.GetList()
                                                   select new SelectListItem
                                                   {
                                                       Text = x.CategoryName,
                                                       Value = x.CategoryId.ToString()
                                                   }).ToList();
            ViewBag.category = categoryValues;
            return View(values);
        }

        [HttpPost]
        public IActionResult Edit(Blog blog)
        {
            BlogValidator blogValidator = new();
            ValidationResult result = blogValidator.Validate(blog);
            if (result.IsValid)
            {
                blog.AddedDate = DateTime.Now;
                blog.Status = true;
                _blogService.Update(blog);
                _notyfService.Success("Blog Güncellendi");
                return RedirectToAction("BlogListByWriter", "Blog");
            }
            else
            {
                List<SelectListItem> categoryValues = (from x in _categoryService.GetList()
                                                       select new SelectListItem
                                                       {
                                                           Text = x.CategoryName,
                                                           Value = x.CategoryId.ToString()
                                                       }).ToList();
                ViewBag.category = categoryValues;
                foreach (var item in result.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
                _notyfService.Error("Blog Güncellenemedi");
                return View();
            }
        }

        [AllowAnonymous]
        public IActionResult Search(string query)
        {
            var values = _blogService.GetSearchResult(query).ToPagedList(1, 6);
            return View(values);
        }

        [AllowAnonymous]
        public IActionResult List(int id)
        {
            var values = _blogService.GetListByCategory(id).ToPagedList(1, 6);
            return View(values);
        }
    }
}
using Business.Abstract;
using Business.ValidationRules.FluentValidation;
using Entities.Concrete;
using FluentValidation.Results;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;

namespace WebUI.Controllers
{
    public class BlogController : Controller
    {
        private readonly IBlogService _blogService;
        private readonly ICategoryService _categoryService;
        private readonly IWriterService _writerService;

        public BlogController(IBlogService blogService, ICategoryService categoryService, IWriterService writerService)
        {
            _blogService = blogService;
            _categoryService = categoryService;
            _writerService = writerService;
        }

        [AllowAnonymous]
        public IActionResult Index()
        {
            var values = _blogService.GetListWithCategory();
            return View(values);
        }

        [AllowAnonymous]
        public IActionResult Detail(int id)
        {
            @ViewBag.commentId = id;
            var values = _blogService.GetListById(id);
            return View(values);
        }

        public IActionResult BlogListByWriter()
        {
            var email = User.Identity.Name;
            var writerId = _writerService.GetList().Where(x => x.Email == email).Select(y => y.WriterId).FirstOrDefault();
            var values = _blogService.GetListWithCategoryByWriter(1);
            return View(values);
        }

        [HttpGet]
        public IActionResult Add()
        {
            List<SelectListItem> categoryValues = (from x in _categoryService.GetList()
                                                   select new SelectListItem
                                                   {
                                                       Text = x.Name,
                                                       Value = x.CategoryId.ToString()
                                                   }).ToList();
            ViewBag.category = categoryValues;
            return View();
        }

        [HttpPost]
        public IActionResult Add(Blog blog)
        {
            BlogValidator blogValidator = new BlogValidator();
            ValidationResult result = blogValidator.Validate(blog);
            if (result.IsValid)
            {
                blog.Status = true;
                blog.Date = DateTime.Parse(DateTime.Now.ToShortDateString());
                blog.WriterId = 1;
                _blogService.Add(blog);
                return RedirectToAction("BlogListByWriter", "Blog");
            }
            else
            {
                foreach (var item in result.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
            }
            return View();
        }

        public IActionResult Delete(int id)
        {
            var values = _blogService.GetById(id);
            _blogService.Delete(values);
            return RedirectToAction("BlogListByWriter");
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var values = _blogService.GetById(id);
            List<SelectListItem> categoryValues = (from x in _categoryService.GetList()
                                                   select new SelectListItem
                                                   {
                                                       Text = x.Name,
                                                       Value = x.CategoryId.ToString()
                                                   }).ToList();
            ViewBag.category = categoryValues;
            return View(values);
        }

        [HttpPost]
        public IActionResult Edit(Blog blog)
        {
            var value = _blogService.GetById(blog.BlogId);
            blog.WriterId = 1;
            blog.Date = value.Date;
            blog.Status = true;
            _blogService.Update(blog);
            return RedirectToAction("BlogListByWriter");
        }
    }
}
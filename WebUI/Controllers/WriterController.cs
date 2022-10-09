using Business.Abstract;
using Business.ValidationRules.FluentValidation;
using Entities.Concrete;
using FluentValidation.Results;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;

namespace WebUI.Controllers
{
    [AllowAnonymous]
    public class WriterController : Controller
    {
        private readonly IBlogService _blogService;
        private readonly ICategoryService _categoryService;
        private readonly IWriterService _writerService;

        public WriterController(IBlogService blogService, ICategoryService categoryService, IWriterService writerService)
        {
            _blogService = blogService;
            _categoryService = categoryService;
            _writerService = writerService;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Dashboard()
        {
            ViewBag.TotalBlog = _blogService.GetList().Count;
            ViewBag.TotalBlogByWriter = _blogService.GetListByWriter(1).Count;
            ViewBag.TotalCategory = _categoryService.GetList().Count;
            return View();
        }

        [HttpGet]
        public IActionResult EditProfile()
        {
            var values = _writerService.GetById(1);
            return View(values);
        }

        [HttpPost]
        public IActionResult EditProfile(Writer writer)
        {
            WriterValidator validationRules = new();
            ValidationResult result = validationRules.Validate(writer);
            if (result.IsValid)
            {
                writer.Status = true;
                _writerService.Update(writer);
                return RedirectToAction("EditProfile", "Writer");
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
    }
}
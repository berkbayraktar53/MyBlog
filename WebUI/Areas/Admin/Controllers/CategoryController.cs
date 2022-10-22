using Business.Abstract;
using Business.ValidationRules.FluentValidation;
using Entities.Concrete;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System;
using X.PagedList;
using FluentValidation.Results;
using AspNetCoreHero.ToastNotification.Abstractions;

namespace WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class CategoryController : Controller
    {
        private readonly ICategoryService _categoryService;
        private readonly INotyfService _notyfService;

        public CategoryController(ICategoryService categoryService, INotyfService notyfService)
        {
            _categoryService = categoryService;
            _notyfService = notyfService;
        }

        public IActionResult Index(int page = 1)
        {
            var values = _categoryService.GetList().ToPagedList(page, 5);
            return View(values);
        }

        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Add(Category category)
        {
            CategoryValidator categoryValidator = new();
            ValidationResult result = categoryValidator.Validate(category);
            if (result.IsValid)
            {
                category.Status = true;
                _categoryService.Add(category);
                _notyfService.Success("Kategori Eklendi");
                return RedirectToAction("Index", "Category");
            }
            else
            {
                foreach (var item in result.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
                _notyfService.Error("Kategori Eklenemedi");
                return View();
            }
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var values = _categoryService.GetById(id);
            return View(values);
        }

        [HttpPost]
        public IActionResult Edit(Category category)
        {
            CategoryValidator categoryValidator = new();
            ValidationResult result = categoryValidator.Validate(category);
            if (result.IsValid)
            {
                category.Status = true;
                _categoryService.Update(category);
                _notyfService.Success("Kategori Güncellendi");
                return RedirectToAction("Index", "Category");
            }
            else
            {
                foreach (var item in result.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
                _notyfService.Error("Kategori Güncellenemedi");
                return View();
            }
        }

        public IActionResult Delete(int id)
        {
            var values = _categoryService.GetById(id);
            _categoryService.Delete(values);
            _notyfService.Success("Kategori Silindi");
            return RedirectToAction("Index", "Category");
        }

        public IActionResult ChangeStatus(int id)
        {
            var values = _categoryService.GetById(id);
            if (values.Status == true)
            {
                values.Status = false;
            }
            else
            {
                values.Status = true;
            }
            _categoryService.Update(values);
            _notyfService.Success("Durum Değiştirildi");
            return RedirectToAction("Index", "Category");
        }
    }
}
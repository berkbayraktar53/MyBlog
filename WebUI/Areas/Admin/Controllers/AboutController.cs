using Business.Abstract;
using Entities.Concrete;
using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Business.ValidationRules.FluentValidation;
using AspNetCoreHero.ToastNotification.Abstractions;

namespace WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class AboutController : Controller
    {
        private readonly IAboutService _aboutService;
        private readonly INotyfService _notyfService;

        public AboutController(IAboutService aboutService, INotyfService notyfService)
        {
            _aboutService = aboutService;
            _notyfService = notyfService;
        }

        public IActionResult Index()
        {
            var values = _aboutService.GetList();
            return View(values);
        }

        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Add(About about)
        {
            AboutValidator aboutValidator = new();
            ValidationResult validationResult = aboutValidator.Validate(about);
            if (validationResult.IsValid)
            {
                about.Status = true;
                _aboutService.Add(about);
                _notyfService.Success("Hakkımda Eklendi");
                return RedirectToAction("Index", "About");
            }
            else
            {
                foreach (var item in validationResult.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
                _notyfService.Error("Hakkımda Eklenemedi");
                return View();
            }
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var values = _aboutService.GetById(id);
            return View(values);
        }

        [HttpPost]
        public IActionResult Edit(About about)
        {
            AboutValidator aboutValidator = new();
            ValidationResult validationResult = aboutValidator.Validate(about);
            if (validationResult.IsValid)
            {
                about.Status = true;
                _aboutService.Update(about);
                _notyfService.Success("Hakkımda Güncellendi");
                return RedirectToAction("Index", "About");
            }
            else
            {
                foreach (var item in validationResult.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
                _notyfService.Error("Hakkımda Güncellenemedi");
                return View();
            }
        }

        public IActionResult Delete(int id)
        {
            var values = _aboutService.GetById(id);
            _aboutService.Delete(values);
            _notyfService.Success("Hakkımda Silindi");
            return RedirectToAction("Index", "About");
        }

        public IActionResult ChangeStatus(int id)
        {
            var values = _aboutService.GetById(id);
            if (values.Status == true)
            {
                values.Status = false;
            }
            else
            {
                values.Status = true;
            }
            _aboutService.Update(values);
            _notyfService.Success("Durum Değiştirildi");
            return RedirectToAction("Index", "About");
        }
    }
}
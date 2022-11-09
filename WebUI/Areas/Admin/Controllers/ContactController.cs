using System;
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
    public class ContactController : Controller
    {
        private readonly IContactService _contactService;
        private readonly INotyfService _notyfService;

        public ContactController(IContactService contactService, INotyfService notyfService)
        {
            _contactService = contactService;
            _notyfService = notyfService;
        }

        public IActionResult Index()
        {
            var values = _contactService.GetList();
            return View(values);
        }

        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Add(Contact contact)
        {
            ContactValidator contactValidator = new();
            ValidationResult validationResult = contactValidator.Validate(contact);
            if (validationResult.IsValid)
            {
                contact.AddedDate = DateTime.Now;
                contact.Status = true;
                _contactService.Add(contact);
                _notyfService.Success("İletişim Eklendi");
                return RedirectToAction("Index", "Contact");
            }
            else
            {
                foreach (var item in validationResult.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
                _notyfService.Error("İletişim Eklenemedi");
                return View();
            }
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var values = _contactService.GetById(id);
            return View(values);
        }

        [HttpPost]
        public IActionResult Edit(Contact contact)
        {
            ContactValidator contactValidator = new();
            ValidationResult validationResult = contactValidator.Validate(contact);
            if (validationResult.IsValid)
            {
                contact.AddedDate = DateTime.Now;
                contact.Status = true;
                _contactService.Update(contact);
                _notyfService.Success("İletişim Güncellendi");
                return RedirectToAction("Index", "Contact");
            }
            else
            {
                foreach (var item in validationResult.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
                _notyfService.Error("İletişim Güncellenemedi");
                return View();
            }
        }

        public IActionResult Delete(int id)
        {
            var values = _contactService.GetById(id);
            _contactService.Delete(values);
            _notyfService.Success("İletişim Silindi");
            return RedirectToAction("Index", "Contact");
        }

        public IActionResult ChangeStatus(int id)
        {
            var values = _contactService.GetById(id);
            if (values.Status == true)
            {
                values.Status = false;
            }
            else
            {
                values.Status = true;
            }
            _contactService.Update(values);
            _notyfService.Success("Durum Değiştirildi");
            return RedirectToAction("Index", "Contact");
        }
    }
}
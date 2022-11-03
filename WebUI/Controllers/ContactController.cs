using AspNetCoreHero.ToastNotification.Abstractions;
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
    public class ContactController : Controller
    {
        private readonly IContactService _contactService;
        private readonly INotyfService _notyfService;

        public ContactController(IContactService contactService, INotyfService notyfService)
        {
            _contactService = contactService;
            _notyfService = notyfService;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Index(Contact contact)
        {
            ContactValidator contactValidator = new();
            ValidationResult validationResult = contactValidator.Validate(contact);
            if (validationResult.IsValid)
            {
                contact.AddedDate = DateTime.Now;
                contact.Status = true;
                _contactService.Add(contact);
                _notyfService.Success("Mesajınız Gönderildi");
                return RedirectToAction("Index", "Contact");
            }
            else
            {
                foreach (var item in validationResult.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
                _notyfService.Error("Mesajınız Gönderilemedi");
                return View();
            }
        }
    }
}
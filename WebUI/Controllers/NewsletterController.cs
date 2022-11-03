using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using AspNetCoreHero.ToastNotification.Abstractions;
using Business.ValidationRules.FluentValidation;
using System.Reflection.Metadata;
using FluentValidation.Results;

namespace WebUI.Controllers
{
    [AllowAnonymous]
    public class NewsletterController : Controller
    {
        private readonly INewsletterService _newsletterService;
        private readonly INotyfService _notyfService;

        public NewsletterController(INewsletterService newsletterService, INotyfService notyfService)
        {
            _newsletterService = newsletterService;
            _notyfService = notyfService;
        }

        [HttpGet]
        public PartialViewResult SubscribeMail()
        {
            return PartialView();
        }

        [HttpPost]
        public IActionResult SubscribeMail(Newsletter newsletter)
        {
            NewsletterValidator newsletterValidator = new();
            ValidationResult validationResult = newsletterValidator.Validate(newsletter);
            if (validationResult.IsValid)
            {
                newsletter.Status = true;
                _newsletterService.Add(newsletter);
                _notyfService.Success("Abone Olundu");
                return RedirectToAction("Index", "Home");
            }
            else
            {
                foreach (var item in validationResult.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
                _notyfService.Error("Abone Olunamadı");
                return View();
            }
        }
    }
}
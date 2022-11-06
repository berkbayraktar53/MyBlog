using AspNetCoreHero.ToastNotification.Abstractions;
using Business.Abstract;
using Business.ValidationRules.FluentValidation;
using Entities.Concrete;
using FluentValidation.Results;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;

namespace WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class NotificationController : Controller
    {
        private readonly INotificationService _notificationService;
        private readonly INotyfService _notyfService;

        public NotificationController(INotificationService notificationService, INotyfService notyfService)
        {
            _notificationService = notificationService;
            _notyfService = notyfService;
        }

        public IActionResult Index()
        {
            var values = _notificationService.GetList();
            return View(values);
        }

        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Add(Entities.Concrete.Notification notification)
        {
            NotificationValidator notificationValidator = new();
            ValidationResult validationResult = notificationValidator.Validate(notification);
            if (validationResult.IsValid)
            {
                notification.AddedDate = DateTime.Now;
                notification.ModifiedDate = DateTime.Now;
                notification.Status = true;
                _notificationService.Add(notification);
                _notyfService.Success("Bildirim Eklendi");
                return RedirectToAction("Index", "Notification");
            }
            else
            {
                foreach (var item in validationResult.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
                _notyfService.Error("Bildirim Eklenemedi");
                return View();
            }
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var values = _notificationService.GetById(id);
            return View(values);
        }

        [HttpPost]
        public IActionResult Edit(Entities.Concrete.Notification notification)
        {
            NotificationValidator notificationValidator = new();
            ValidationResult validationResult = notificationValidator.Validate(notification);
            if (validationResult.IsValid)
            {
                notification.ModifiedDate = DateTime.Now;
                notification.Status = true;
                _notificationService.Update(notification);
                _notyfService.Success("Bildirim Güncellendi");
                return RedirectToAction("Index", "Notification");
            }
            else
            {
                foreach (var item in validationResult.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
                _notyfService.Error("Bildirim Güncellenemedi");
                return View();
            }
        }

        public IActionResult Delete(int id)
        {
            var values = _notificationService.GetById(id);
            _notificationService.Delete(values);
            _notyfService.Success("Bildirim Silindi");
            return RedirectToAction("Index", "Notification");
        }

        public IActionResult ChangeStatus(int id)
        {
            var values = _notificationService.GetById(id);
            if (values.Status == true)
            {
                values.Status = false;
            }
            else
            {
                values.Status = true;
            }
            _notificationService.Update(values);
            _notyfService.Success("Durum Değiştirildi");
            return RedirectToAction("Index", "Notification");
        }
    }
}
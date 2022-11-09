using AspNetCoreHero.ToastNotification.Abstractions;
using Business.Abstract;
using Business.Concrete;
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

namespace WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class MessageController : Controller
    {
        private readonly UserManager<User> _userManager;
        private readonly IMessageService _messageService;
        private readonly INotyfService _notyfService;
        private readonly IUserService _userService;

        public MessageController(UserManager<User> userManager, IMessageService messageService, INotyfService notyfService, IUserService userService)
        {
            _userManager = userManager;
            _messageService = messageService;
            _notyfService = notyfService;
            _userService = userService;
        }

        public IActionResult InBox()
        {
            var userId = _userManager.FindByNameAsync(User.Identity.Name).Result.Id;
            var values = _messageService.GetInBoxListByUser(userId);
            return View(values);
        }

        public IActionResult SendBox()
        {
            var userId = _userManager.FindByNameAsync(User.Identity.Name).Result.Id;
            var values = _messageService.GetSendBoxListByUser(userId);
            return View(values);
        }

        [HttpGet]
        public IActionResult SendMessage()
        {
            List<SelectListItem> userValues = (from x in _userService.GetList()
                                               select new SelectListItem
                                               {
                                                   Text = x.NameSurname,
                                                   Value = x.Id.ToString()
                                               }).ToList();
            ViewBag.users = userValues;
            return View();
        }

        [HttpPost]
        public IActionResult SendMessage(Message message)
        {
            MessageValidator messageValidator = new();
            ValidationResult validationResult = messageValidator.Validate(message);
            if (validationResult.IsValid)
            {
                var userId = _userManager.FindByNameAsync(User.Identity.Name).Result.Id;
                message.SenderId = userId;
                message.AddedDate = DateTime.Now;
                message.ModifiedDate = DateTime.Now;
                message.Status = true;
                _messageService.Add(message);
                _notyfService.Success("Mesaj Gönderildi");
                return RedirectToAction("SendBox", "Message");
            }
            else
            {
                List<SelectListItem> userValues = (from x in _userService.GetList()
                                                   select new SelectListItem
                                                   {
                                                       Text = x.NameSurname,
                                                       Value = x.Id.ToString()
                                                   }).ToList();
                ViewBag.users = userValues;
                foreach (var item in validationResult.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
                _notyfService.Error("Mesaj Gönderilemedi");
                return View();
            }
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            List<SelectListItem> userValues = (from x in _userService.GetList()
                                               select new SelectListItem
                                               {
                                                   Text = x.NameSurname,
                                                   Value = x.Id.ToString()
                                               }).ToList();
            ViewBag.users = userValues;
            var values = _messageService.GetById(id);
            return View(values);
        }

        [HttpPost]
        public IActionResult Edit(Message message)
        {
            MessageValidator messageValidator = new();
            ValidationResult validationResult = messageValidator.Validate(message);
            if (validationResult.IsValid)
            {
                var userId = _userManager.FindByNameAsync(User.Identity.Name).Result.Id;
                message.ReceiverId = userId;
                message.ModifiedDate = DateTime.Now;
                message.Status = true;
                _messageService.Update(message);
                _notyfService.Success("Mesaj Güncellendi");
                return RedirectToAction("InBox", "Message");
            }
            else
            {
                List<SelectListItem> userValues = (from x in _userService.GetList()
                                                   select new SelectListItem
                                                   {
                                                       Text = x.NameSurname,
                                                       Value = x.Id.ToString()
                                                   }).ToList();
                ViewBag.users = userValues;
                foreach (var item in validationResult.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
                _notyfService.Error("Hakkımda Güncellenemedi");
                return View();
            }
        }

        public IActionResult ChangeStatus(int id)
        {
            var values = _messageService.GetById(id);
            if (values.Status == true)
            {
                values.Status = false;
            }
            else
            {
                values.Status = true;
            }
            _messageService.Update(values);
            _notyfService.Success("Durum Değiştirildi");
            return RedirectToAction("InBox", "Message");
        }

        public IActionResult Delete(int id)
        {
            var values = _messageService.GetById(id);
            _messageService.Delete(values);
            _notyfService.Success("Mesaj Silindi");
            return RedirectToAction("InBox", "Message");
        }
    }
}
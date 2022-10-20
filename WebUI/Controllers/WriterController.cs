using AspNetCoreHero.ToastNotification.Abstractions;
using Business.Abstract;
using Business.ValidationRules.FluentValidation;
using Entities.Concrete;
using FluentValidation.Results;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.IO;
using System.Linq;
using WebUI.Models;

namespace WebUI.Controllers
{
    public class WriterController : Controller
    {
        private readonly IBlogService _blogService;
        private readonly ICategoryService _categoryService;
        private readonly IMessageFkService _messageFkService;
        private readonly INotificationService _notificationService;
        private readonly INotyfService _notyfService;
        private readonly IWriterService _writerService;

        public WriterController(IBlogService blogService, ICategoryService categoryService, IMessageFkService messageFkService, INotificationService notificationService, INotyfService notyfService, IWriterService writerService)
        {
            _blogService = blogService;
            _categoryService = categoryService;
            _messageFkService = messageFkService;
            _notificationService = notificationService;
            _notyfService = notyfService;
            _writerService = writerService;
        }

        public IActionResult Dashboard()
        {
            var userEmail = User.Identity.Name;
            var writerId = _writerService.GetList().Where(x => x.Email == userEmail).Select(y => y.WriterId).FirstOrDefault();
            ViewBag.totalBlogCount = _blogService.GetListWithCategoryByWriter(writerId).Count;
            ViewBag.totalMessageCount = _messageFkService.GetInboxListByWriter(writerId).Count;
            ViewBag.totalNotificationCount = _notificationService.GetList().Count();
            return View();
        }

        public IActionResult Profile()
        {
            var userEmail = User.Identity.Name;
            var writerId = _writerService.GetList().Where(x => x.Email == userEmail).Select(y => y.WriterId).FirstOrDefault();
            var values = _writerService.GetWriterById(writerId);
            return View(values);
        }

        [HttpGet]
        public IActionResult EditProfile()
        {
            var userEmail = User.Identity.Name;
            var writerId = _writerService.GetList().Where(x => x.Email == userEmail).Select(y => y.WriterId).FirstOrDefault();
            var values = _writerService.GetById(writerId);
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
                _notyfService.Success("Profil Güncellendi");
                return RedirectToAction("Profile", "Writer");
            }
            else
            {
                foreach (var item in result.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
                _notyfService.Error("Profil Güncellenemedi");
                return View();
            }
        }

        [HttpGet]
        public IActionResult AddWriter()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddWriter(WriterProfileImage writerProfileImage, Writer writer)
        {
            if (writerProfileImage.Image != null)
            {
                var extension = Path.GetExtension(writerProfileImage.Image.FileName);
                var newImageName = Guid.NewGuid() + extension;
                var location = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/WriterImageFiles/", newImageName);
                var stream = new FileStream(location, FileMode.Create);
                writerProfileImage.Image.CopyTo(stream);
                writer.Image = newImageName;
            }
            writer.Email = writerProfileImage.Email;
            writer.Name = writerProfileImage.Name;
            writer.Password = writerProfileImage.Password;
            writer.About = writerProfileImage.About;
            writer.Status = true;
            _writerService.Add(writer);
            return RedirectToAction("Dashboard", "Writer");
        }
    }
}
using AspNetCoreHero.ToastNotification.Abstractions;
using Business.Abstract;
using Business.ValidationRules.FluentValidation;
using Entities.Concrete;
using FluentValidation.Results;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using WebUI.Models;

namespace WebUI.Controllers
{
    public class WriterController : Controller
    {
        private readonly UserManager<User> _userManager;
        private readonly IBlogService _blogService;
        private readonly ICategoryService _categoryService;
        private readonly IMessageFkService _messageFkService;
        private readonly INotificationService _notificationService;
        private readonly INotyfService _notyfService;
        private readonly IUserService _userService;
        private readonly IWriterService _writerService;

        public WriterController(UserManager<User> userManager, IBlogService blogService, ICategoryService categoryService, IMessageFkService messageFkService, INotificationService notificationService, INotyfService notyfService, IUserService userService, IWriterService writerService)
        {
            _userManager = userManager;
            _blogService = blogService;
            _categoryService = categoryService;
            _messageFkService = messageFkService;
            _notificationService = notificationService;
            _notyfService = notyfService;
            _userService = userService;
            _writerService = writerService;
        }

        public IActionResult Dashboard()
        {
            var userName = User.Identity.Name;
            var writerId = _writerService.GetList().Where(x => x.Name == userName).Select(y => y.WriterId).FirstOrDefault();
            ViewBag.totalBlogCount = _blogService.GetListWithCategoryByWriter(writerId).Count;
            ViewBag.totalMessageCount = _messageFkService.GetInboxListByWriter(writerId).Count;
            ViewBag.totalNotificationCount = _notificationService.GetList().Count();
            return View();
        }

        public IActionResult Profile()
        {
            var userName = User.Identity.Name;
            var writerId = _writerService.GetList().Where(x => x.Name == userName).Select(y => y.WriterId).FirstOrDefault();
            var values = _writerService.GetWriterById(writerId);
            return View(values);
        }

        [HttpGet]
        public async Task<IActionResult> EditProfile()
        {
            UserUpdateViewModel model = new();
            var values = await _userManager.FindByNameAsync(User.Identity.Name);
            model.FullName = values.FullName;
            model.UserName = values.UserName;
            model.Email = values.Email;
            model.ImageUrl = values.ImageUrl;
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> EditProfile(UserUpdateViewModel model)
        {
            var values = await _userManager.FindByNameAsync(User.Identity.Name);
            values.FullName = model.FullName;
            values.UserName = model.UserName;
            values.Email = model.Email;
            values.ImageUrl = model.ImageUrl;
            values.PasswordHash = _userManager.PasswordHasher.HashPassword(values, model.Password);
            var result = await _userManager.UpdateAsync(values);
            _notyfService.Success("Yazar güncellendi");
            return RedirectToAction("Dashboard", "Writer");
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
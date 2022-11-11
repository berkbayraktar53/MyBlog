using AspNetCoreHero.ToastNotification.Abstractions;
using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.IO;
using System.Threading.Tasks;
using WebUI.Models;

namespace WebUI.Controllers
{
    [Authorize(Roles = "Writer")]
    public class WriterController : Controller
    {
        private readonly UserManager<User> _userManager;
        private readonly IBlogService _blogService;
        private readonly ICategoryService _categoryService;
        private readonly IMessageService _messageService;
        private readonly INotificationService _notificationService;
        private readonly INotyfService _notyfService;
        private readonly IUserService _userService;

        public WriterController(UserManager<User> userManager, IBlogService blogService, ICategoryService categoryService, IMessageService messageService, INotificationService notificationService, INotyfService notyfService, IUserService userService)
        {
            _userManager = userManager;
            _blogService = blogService;
            _categoryService = categoryService;
            _messageService = messageService;
            _notificationService = notificationService;
            _notyfService = notyfService;
            _userService = userService;
        }

        public IActionResult Dashboard()
        {
            var userId = _userManager.FindByNameAsync(User.Identity.Name).Result.Id;
            ViewBag.totalBlogCount = _blogService.GetListWithCategoryByUser(userId).Count;
            ViewBag.totalMessageCount = _messageService.GetInBoxListByUser(userId).Count;
            ViewBag.totalNotificationCount = _notificationService.GetList().Count;
            return View();
        }

        public IActionResult Profile()
        {
            var userId = _userManager.FindByNameAsync(User.Identity.Name).Result.Id;
            var values = _userService.GetById(userId);
            return View(values);
        }

        [HttpGet]
        public async Task<IActionResult> EditProfile()
        {
            UserUpdateViewModel model = new();
            var values = await _userManager.FindByNameAsync(User.Identity.Name);
            model.FullName = values.NameSurname;
            model.UserName = values.UserName;
            model.Email = values.Email;
            model.ImageUrl = values.ImageUrl;
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> EditProfile(UserUpdateViewModel model)
        {
            var values = await _userManager.FindByNameAsync(User.Identity.Name);
            values.NameSurname = model.FullName;
            values.UserName = model.UserName;
            values.Email = model.Email;
            values.ImageUrl = model.ImageUrl;
            values.PasswordHash = _userManager.PasswordHasher.HashPassword(values, model.Password);
            await _userManager.UpdateAsync(values);
            _notyfService.Success("Yazar güncellendi");
            return RedirectToAction("Dashboard", "Writer");
        }

        [HttpGet]
        public IActionResult AddWriter()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddWriter(UserProfileImage userProfileImage, User writer)
        {
            if (userProfileImage.Image != null)
            {
                var extension = Path.GetExtension(userProfileImage.Image.FileName);
                var newImageName = Guid.NewGuid() + extension;
                var location = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/WriterImageFiles/", newImageName);
                var stream = new FileStream(location, FileMode.Create);
                userProfileImage.Image.CopyTo(stream);
                writer.ImageUrl = newImageName;
            }
            writer.Email = userProfileImage.Email;
            writer.UserName = userProfileImage.Name;
            writer.PasswordHash = userProfileImage.Password;
            _userManager.CreateAsync(writer);
            return RedirectToAction("Dashboard", "Writer");
        }
    }
}
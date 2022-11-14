using Business.Abstract;
using Business.ValidationRules.FluentValidation;
using Entities.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using FluentValidation.Results;
using AspNetCoreHero.ToastNotification.Abstractions;
using Microsoft.AspNetCore.Identity;
using System.Threading.Tasks;
using System.Linq;
using WebUI.Models;
using WebUI.Areas.Admin.Models;

namespace WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class WriterController : Controller
    {
        private readonly RoleManager<Role> _roleManager;
        private readonly UserManager<User> _userManager;
        private readonly INotyfService _notyfService;
        private readonly IUserService _userService;

        public WriterController(RoleManager<Role> roleManager, UserManager<User> userManager, INotyfService notyfService, IUserService userService)
        {
            _roleManager = roleManager;
            _userManager = userManager;
            _notyfService = notyfService;
            _userService = userService;
        }

        public IActionResult Index()
        {
            var values = _userService.GetListWithBlog();
            return View(values);
        }

        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Add(User user)
        {
            UserValidator userValidator = new();
            ValidationResult validationResult = userValidator.Validate(user);
            if (validationResult.IsValid)
            {
                user.PasswordHash = _userManager.PasswordHasher.HashPassword(user, user.PasswordHash);
                user.Status = true;
                await _userManager.CreateAsync(user);
                _notyfService.Success("Yazar Eklendi");
                return RedirectToAction("Index", "Writer");
            }
            else
            {
                foreach (var item in validationResult.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
                _notyfService.Error("Yazar Eklenemedi");
                return View(user);
            }
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var values = _userService.GetById(id);
            WriterUpdateViewModel writerUpdateViewModel = new();
            writerUpdateViewModel.Id = values.Id;
            writerUpdateViewModel.ImageUrl = values.ImageUrl;
            writerUpdateViewModel.NameSurname = values.NameSurname;
            writerUpdateViewModel.Email = values.Email;
            writerUpdateViewModel.UserName = values.UserName;
            writerUpdateViewModel.PasswordHash = values.PasswordHash;
            return View(writerUpdateViewModel);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(WriterUpdateViewModel writerUpdateViewModel)
        {
            var user = _userManager.FindByNameAsync(writerUpdateViewModel.UserName).Result;
            user.ImageUrl = writerUpdateViewModel.ImageUrl;
            user.NameSurname = writerUpdateViewModel.NameSurname;
            user.Email = writerUpdateViewModel.Email;
            user.UserName = writerUpdateViewModel.UserName;
            writerUpdateViewModel.PasswordHash = _userManager.PasswordHasher.HashPassword(user, writerUpdateViewModel.PasswordHash);
            await _userManager.UpdateAsync(user);
            _notyfService.Success("Yazar Güncellendi");
            return RedirectToAction("Index", "Writer");
        }

        public IActionResult Delete(int id)
        {
            var values = _userService.GetById(id);
            _userService.Delete(values);
            _notyfService.Success("Yazar Silindi");
            return RedirectToAction("Index", "Writer");
        }

        public async Task<IActionResult> ChangeStatus(int id)
        {
            var user = _userManager.FindByIdAsync(id.ToString()).Result;
            if (user.Status == true)
            {
                user.Status = false;
                await _userManager.RemoveFromRoleAsync(user, "Writer");
            }
            else
            {
                user.Status = true;
                await _userManager.AddToRoleAsync(user, "Writer");
            }
            await _userManager.UpdateAsync(user);
            _notyfService.Success("Durum Değiştirildi");
            return RedirectToAction("Index", "Writer");
        }

        [HttpGet]
        public async Task<IActionResult> AssignRole(int id)
        {
            var user = _userService.GetById(id);
            var roles = _roleManager.Roles.ToList();
            TempData["UserId"] = user.Id;
            var userRoles = await _userManager.GetRolesAsync(user);
            List<RoleAssignViewModel> models = new();
            foreach (var item in roles)
            {
                RoleAssignViewModel model = new()
                {
                    RoleId = item.Id,
                    Name = item.Name,
                    Exists = userRoles.Contains(item.Name)
                };
                models.Add(model);
            }
            return View(models);
        }

        [HttpPost]
        public async Task<IActionResult> AssignRole(List<RoleAssignViewModel> roleAssignViewModels)
        {
            var userId = (int)TempData["UserId"];
            var user = _userManager.Users.FirstOrDefault(X => X.Id == userId);
            foreach (var item in roleAssignViewModels)
            {
                if (item.Exists)
                {
                    await _userManager.AddToRoleAsync(user, item.Name);
                }
                else
                {
                    await _userManager.RemoveFromRoleAsync(user, item.Name);
                }
            }
            return RedirectToAction("Index", "Writer");
        }
    }
}
using Entities.Concrete;
using Microsoft.AspNetCore.Mvc;
using WebUI.Areas.Admin.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authorization;
using AspNetCoreHero.ToastNotification.Abstractions;
using System.Threading.Tasks;

namespace WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class SettingController : Controller
    {
        private readonly UserManager<User> _userManager;
        private readonly INotyfService _notyfService;

        public SettingController(UserManager<User> userManager, INotyfService notyfService)
        {
            _userManager = userManager;
            _notyfService = notyfService;
        }

        [HttpGet]
        public IActionResult ChangePassword()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> ChangePassword(ChangePasswordViewModel changePasswordViewModel)
        {
            if (ModelState.IsValid)
            {
                var user = _userManager.FindByNameAsync(User.Identity.Name).Result;
                if (changePasswordViewModel.NewPassword == changePasswordViewModel.RePassword)
                {
                    var checkOldPassword = _userManager.CheckPasswordAsync(user, changePasswordViewModel.CurrentPassword);
                    if (checkOldPassword.Result)
                    {
                        user.PasswordHash = _userManager.PasswordHasher.HashPassword(user, changePasswordViewModel.NewPassword);
                        await _userManager.UpdateAsync(user);
                        _notyfService.Success("Şifreniz Değiştirildi");
                        return RedirectToAction("ChangePassword", "Setting");
                    }
                    else
                    {
                        _notyfService.Error("Mevcut Şifreniz Hatalı");
                        return View(changePasswordViewModel);
                    }
                }
                else
                {
                    _notyfService.Error("Şifreler Birbiriyle Uyuşmuyor");
                    return View(changePasswordViewModel);
                }
            }
            _notyfService.Error("Lütfen Eksik Yerleri Doldurunuz");
            return View(changePasswordViewModel);
        }
    }
}
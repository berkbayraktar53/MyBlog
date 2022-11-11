using AspNetCoreHero.ToastNotification.Abstractions;
using Business.Concrete;
using Entities.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using WebUI.Models;

namespace WebUI.Controllers
{
    [AllowAnonymous]
    public class AccountController : Controller
    {
        private readonly RoleManager<Role> _roleManager;
        private readonly SignInManager<User> _signInManager; // Giriş yapmak için gereken Microsoft kütüphanesi
        private readonly UserManager<User> _userManager; // Kayıt olmak için gereken Microsoft kütüphanesi
        private readonly INotyfService _notyfService;

        public AccountController(RoleManager<Role> roleManager, SignInManager<User> signInManager, UserManager<User> userManager, INotyfService notyfService)
        {
            _roleManager = roleManager;
            _signInManager = signInManager;
            _userManager = userManager;
            _notyfService = notyfService;
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(UserLoginViewModel userLoginViewModel)
        {
            var result = await _signInManager.PasswordSignInAsync(userLoginViewModel.UserName, userLoginViewModel.Password, false, true);
            if (result.Succeeded)
            {
                var user = _userManager.FindByNameAsync(userLoginViewModel.UserName).Result;
                if (user.Status == false)
                {
                    _notyfService.Information("Hesabınız Admin Onayından Sonra Aktif Olacaktır. Lütfen Bekleyiniz...");
                    return RedirectToAction("Login", "Account");
                }
                var getRoles = _userManager.GetRolesAsync(user).Result;
                if (getRoles.Contains("Admin"))
                {
                    _notyfService.Success("Hoşgeldin Admin");
                    return RedirectToAction("Index", "Dashboard", new { area = "Admin" });
                }
                else
                {
                    _notyfService.Success("Hoşgeldiniz");
                    return RedirectToAction("Dashboard", "Writer");
                }
            }
            else
            {
                _notyfService.Error("Kullanıcı Adı veya Şifre Hatalı");
                return RedirectToAction("Login", "Account");
            }
        }

        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(UserRegisterViewModel userRegisterViewModel)
        {
            if (ModelState.IsValid)
            {
                User user = new()
                {
                    Email = userRegisterViewModel.Email,
                    UserName = userRegisterViewModel.UserName,
                    NameSurname = userRegisterViewModel.FullName
                };
                var result = await _userManager.CreateAsync(user, userRegisterViewModel.Password);
                if (result.Succeeded)
                {
                    await _userManager.AddToRoleAsync(user, "Writer");
                    _notyfService.Success("Kayıt Başarılı.");
                    _notyfService.Information("Hesabınız Admin Onayından Sonra Aktif Olacaktır. Lütfen Bekleyiniz...");
                    return RedirectToAction("Login", "Account");
                }
                else
                {
                    foreach (var item in result.Errors)
                    {
                        ModelState.AddModelError("", item.Description);
                    }
                    _notyfService.Error("Kayıt Başarısız");
                }
            }
            _notyfService.Error("Lütfen Eksik Yerleri Doldurunuz");
            return View(userRegisterViewModel);
        }

        public async Task<IActionResult> LogOut()
        {
            await _signInManager.SignOutAsync();
            _notyfService.Success("Çıkış Yaptınız");
            return RedirectToAction("Login", "Account");
        }
    }
}
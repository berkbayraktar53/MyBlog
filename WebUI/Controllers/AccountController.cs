using AspNetCoreHero.ToastNotification.Abstractions;
using Business.Abstract;
using Business.ValidationRules.FluentValidation;
using DataAccess.Concrete.EntityFramework.Contexts;
using Entities.Concrete;
using FluentValidation.Results;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using WebUI.Models;

namespace WebUI.Controllers
{
    [AllowAnonymous]
    public class AccountController : Controller
    {
        private readonly SignInManager<User> _signInManager; // Giriş yapmak için gereken Microsoft kütüphanesi
        private readonly UserManager<User> _userManager; // Kayıt olmak için gereken Microsoft kütüphanesi
        private readonly INotyfService _notyfService;
        private readonly IWriterService _writerService;

        public AccountController(SignInManager<User> signInManager, UserManager<User> userManager, INotyfService notyfService, IWriterService writerService)
        {
            _signInManager = signInManager;
            _userManager = userManager;
            _notyfService = notyfService;
            _writerService = writerService;
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(UserLoginViewModel userLoginViewModel)
        {
            DatabaseContext context = new DatabaseContext();
            var result = await _signInManager.PasswordSignInAsync(userLoginViewModel.UserName, userLoginViewModel.Password, false, true);
            if (result.Succeeded)
            {
                _notyfService.Success("Giriş başarılı");
                return RedirectToAction("Dashboard", "Writer");
            }
            else
            {
                _notyfService.Error("Kullanıcı adı veya şifre hatalı");
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
                User user = new User()
                {
                    Email = userRegisterViewModel.Email,
                    UserName = userRegisterViewModel.UserName,
                    FullName = userRegisterViewModel.FullName
                };
                var result = await _userManager.CreateAsync(user, userRegisterViewModel.Password);
                if (result.Succeeded)
                {
                    return RedirectToAction("Login", "Account");
                }
                else
                {
                    foreach (var item in result.Errors)
                    {
                        ModelState.AddModelError("", item.Description);
                    }
                }
            }
            return View(userRegisterViewModel);
        }

        public async Task<IActionResult> LogOut()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Index", "Home");
        }
    }
}
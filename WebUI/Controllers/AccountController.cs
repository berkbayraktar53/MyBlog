﻿using AspNetCoreHero.ToastNotification.Abstractions;
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
        private readonly SignInManager<User> _signInManager; // Giriş yapmak için gereken Microsoft kütüphanesi
        private readonly UserManager<User> _userManager; // Kayıt olmak için gereken Microsoft kütüphanesi
        private readonly INotyfService _notyfService;

        public AccountController(SignInManager<User> signInManager, UserManager<User> userManager, INotyfService notyfService)
        {
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
                User user = new()
                {
                    Email = userRegisterViewModel.Email,
                    UserName = userRegisterViewModel.UserName,
                    NameSurname = userRegisterViewModel.FullName
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
            await _signInManager.SignOutAsync();
            _notyfService.Success("Çıkış yaptınız");
            return RedirectToAction("Login", "Account");
        }
    }
}
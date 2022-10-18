﻿using Business.Abstract;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace WebUI.Controllers
{
    public class AboutController : Controller
    {
        private readonly IAboutService _aboutService;

        public AboutController(IAboutService aboutService)
        {
            _aboutService = aboutService;
        }

        [AllowAnonymous]
        public IActionResult Index()
        {
            var values = _aboutService.GetList();
            return View(values);
        }

        public PartialViewResult SocialMediaAccount()
        {
            return PartialView();
        }
    }
}
using Business.Abstract;
using Business.ValidationRules.FluentValidation;
using DataAccess.Concrete.EntityFramework.Contexts;
using Entities.Concrete;
using FluentValidation.Results;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace WebUI.Controllers
{
    [AllowAnonymous]
    public class AccountController : Controller
    {
        private readonly IWriterService _writerService;

        public AccountController(IWriterService writerService)
        {
            _writerService = writerService;
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(Writer writer)
        {
            DatabaseContext context = new DatabaseContext();
            var user = context.Writers.FirstOrDefault(x => x.Email == writer.Email && x.Password == writer.Password);
            if (user != null)
            {
                var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name, writer.Email)
                };
                var userIdentity = new ClaimsIdentity(claims, "claim");
                ClaimsPrincipal principal = new(userIdentity);
                await HttpContext.SignInAsync(principal);
                return RedirectToAction("Index", "Writer");
            }
            else
            {
                return View();
            }
        }

        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Register(Writer writer)
        {
            WriterValidator writerValidator = new WriterValidator();
            ValidationResult results = writerValidator.Validate(writer);
            if (results.IsValid)
            {
                writer.Status = true;
                writer.About = "Blog Yazarı";
                _writerService.Add(writer);
                return RedirectToAction("Index", "Blog");
            }
            else
            {
                foreach (var item in results.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
            }
            return View();
        }
    }
}
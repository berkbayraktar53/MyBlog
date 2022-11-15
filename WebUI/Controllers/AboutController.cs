using Business.Abstract;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace WebUI.Controllers
{
    [Authorize(Roles = "Writer")]
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
            var values = _aboutService.GetListByActiveStatus();
            return View(values);
        }

        public PartialViewResult SocialMediaAccount()
        {
            return PartialView();
        }
    }
}
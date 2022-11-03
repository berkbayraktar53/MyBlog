using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace WebUI.ViewComponents.Writer
{
    public class WriterProfileNavbar : ViewComponent
    {
        private readonly UserManager<User> _userManager;
        private readonly IUserService _userService;

        public WriterProfileNavbar(UserManager<User> userManager, IUserService userService)
        {
            _userManager = userManager;
            _userService = userService;
        }

        public IViewComponentResult Invoke()
        {
            var userId = _userManager.FindByNameAsync(User.Identity.Name).Result.Id;
            var values = _userService.GetById(userId);
            return View(values);
        }
    }
}
using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace WebUI.ViewComponents.Writer
{
    public class WriterAboutOnDashboard : ViewComponent
    {
        private readonly UserManager<User> _userManager;
        private readonly IUserService _userService;

        public WriterAboutOnDashboard(UserManager<User> userManager, IUserService userService)
        {
            _userManager = userManager;
            _userService = userService;
        }

        public IViewComponentResult Invoke()
        {
            var userId = _userManager.FindByNameAsync(User.Identity.Name).Result.Id;
            var userEmail = _userManager.FindByNameAsync(User.Identity.Name).Result.Email;
            var writerId = _userService.GetList().Where(x => x.Email == userEmail).Select(y => y.Id).FirstOrDefault();
            var values = _userService.GetById(writerId);
            return View(values);
        }
    }
}
using Entities.Concrete;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace WebUI.Areas.Admin.ViewComponents.Writer
{
    public class WriterProfileName : ViewComponent
    {
        private readonly UserManager<User> _userManager;

        public WriterProfileName(UserManager<User> userManager)
        {
            _userManager = userManager;
        }

        public IViewComponentResult Invoke()
        {
            var writerName = _userManager.FindByNameAsync(User.Identity.Name).Result;
            return View(writerName);
        }
    }
}
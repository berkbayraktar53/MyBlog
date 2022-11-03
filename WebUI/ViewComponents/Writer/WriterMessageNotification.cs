using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace WebUI.ViewComponents.Writer
{
    public class WriterMessageNotification : ViewComponent
    {
        private readonly UserManager<User> _userManager;
        private readonly IMessageService _messageService;
        private readonly IUserService _userService;

        public WriterMessageNotification(UserManager<User> userManager, IMessageService messageService, IUserService userService)
        {
            _userManager = userManager;
            _messageService = messageService;
            _userService = userService;
        }

        public IViewComponentResult Invoke()
        {
            var userId = _userManager.FindByNameAsync(User.Identity.Name).Result.Id;
            var values = _messageService.GetInBoxListByUser(userId);
            return View(values);
        }
    }
}
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Business.Abstract;
using Microsoft.AspNetCore.Identity;
using Entities.Concrete;

namespace WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class DashboardController : Controller
    {
        private readonly UserManager<User> _userManager;
        private readonly IBlogService _blogService;
        private readonly IMessageService _messageService;
        private readonly INotificationService _notificationService;
        private readonly IUserService _userService;

        public DashboardController(UserManager<User> userManager, IBlogService blogService, IMessageService messageService, INotificationService notificationService, IUserService userService)
        {
            _userManager = userManager;
            _blogService = blogService;
            _messageService = messageService;
            _notificationService = notificationService;
            _userService = userService;
        }

        public IActionResult Index()
        {
            var writer = _userManager.FindByNameAsync(User.Identity.Name).Result;
            ViewBag.totalBlogCount = _blogService.GetList().Count;
            ViewBag.totalMessageCount = _messageService.GetInBoxListByUser(writer.Id).Count;
            ViewBag.totalNotificationCount = _notificationService.GetList().Count;
            ViewBag.totalUserCount = _userService.GetList().Count;
            return View();
        }
    }
}
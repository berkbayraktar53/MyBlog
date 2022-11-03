using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;

namespace WebUI.Controllers
{
    public class MessageController : Controller
    {
        private readonly UserManager<User> _userManager;
        private readonly IMessageService _messageService;
        private readonly IUserService _userService;

        public MessageController(UserManager<User> userManager, IMessageService messageService, IUserService userService)
        {
            _userManager = userManager;
            _messageService = messageService;
            _userService = userService;
        }

        public IActionResult InBox()
        {
            var userId = _userManager.FindByNameAsync(User.Identity.Name).Result.Id;
            var values = _messageService.GetInBoxListByUser(userId);
            return View(values);
        }

        public IActionResult SendBox()
        {
            var userId = _userManager.FindByNameAsync(User.Identity.Name).Result.Id;
            var values = _messageService.GetSendBoxListByUser(userId);
            return View(values);
        }

        public IActionResult Detail(int id)
        {
            var values = _messageService.GetById(id);
            ViewBag.senderName = _userService.GetById((int)values.SenderId).UserName;
            return View(values);
        }

        [HttpGet]
        public IActionResult SendMessage()
        {
            return View();
        }

        [HttpPost]
        public IActionResult SendMessage(Message message)
        {
            var userName = User.Identity.Name;
            var writerId = _userService.GetList().Where(x => x.UserName == userName).Select(y => y.Id).FirstOrDefault();
            message.SenderId = writerId;
            message.ReceiverId = 1;
            message.Status = true;
            message.AddedDate = Convert.ToDateTime(DateTime.Now.ToShortDateString());
            _messageService.Add(message);
            return RedirectToAction("InBox");
        }
    }
}
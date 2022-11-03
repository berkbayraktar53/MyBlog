using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;

namespace WebUI.Controllers
{
    public class MessageController : Controller
    {
        private readonly IMessageService _messageService;
        private readonly IWriterService _writerService;

        public MessageController(IMessageService messageService, IWriterService writerService)
        {
            _messageService = messageService;
            _writerService = writerService;
        }

        public IActionResult InBox()
        {
            var userName = User.Identity.Name;
            var writerId = _writerService.GetList().Where(x => x.UserName == userName).Select(y => y.Id).FirstOrDefault();
            var values = _messageService.GetInBoxListByWriter(writerId);
            return View(values);
        }

        public IActionResult SendBox()
        {
            var userName = User.Identity.Name;
            var writerId = _writerService.GetList().Where(x => x.UserName == userName).Select(y => y.Id).FirstOrDefault();
            var values = _messageService.GetSendBoxListByWriter(writerId);
            return View(values);
        }

        public IActionResult Detail(int id)
        {
            var values = _messageService.GetById(id);
            ViewBag.senderName = _writerService.GetById((int)values.SenderId).UserName;
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
            var writerId = _writerService.GetList().Where(x => x.UserName == userName).Select(y => y.Id).FirstOrDefault();
            message.SenderId = writerId;
            message.ReceiverId = 1;
            message.Status = true;
            message.Date = Convert.ToDateTime(DateTime.Now.ToShortDateString());
            _messageService.Add(message);
            return RedirectToAction("InBox");
        }
    }
}
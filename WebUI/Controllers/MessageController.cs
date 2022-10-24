using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;

namespace WebUI.Controllers
{
    public class MessageController : Controller
    {
        private readonly IMessageFkService _messageFkService;
        private readonly IWriterService _writerService;

        public MessageController(IMessageFkService messageFkService, IWriterService writerService)
        {
            _messageFkService = messageFkService;
            _writerService = writerService;
        }

        public IActionResult InBox()
        {
            var userName = User.Identity.Name;
            var writerId = _writerService.GetList().Where(x => x.Name == userName).Select(y => y.WriterId).FirstOrDefault();
            var values = _messageFkService.GetInBoxListByWriter(writerId);
            return View(values);
        }

        public IActionResult SendBox()
        {
            var userName = User.Identity.Name;
            var writerId = _writerService.GetList().Where(x => x.Name == userName).Select(y => y.WriterId).FirstOrDefault();
            var values = _messageFkService.GetSendBoxListByWriter(writerId);
            return View(values);
        }

        public IActionResult Detail(int id)
        {
            var values = _messageFkService.GetById(id);
            ViewBag.senderName = _writerService.GetById((int)values.SenderId).Name;
            return View(values);
        }

        [HttpGet]
        public IActionResult SendMessage()
        {
            return View();
        }

        [HttpPost]
        public IActionResult SendMessage(MessageFk message)
        {
            var userName = User.Identity.Name;
            var writerId = _writerService.GetList().Where(x => x.Name == userName).Select(y => y.WriterId).FirstOrDefault();
            message.SenderId = writerId;
            message.ReceiverId = 1;
            message.Status = true;
            message.Date = Convert.ToDateTime(DateTime.Now.ToShortDateString());
            _messageFkService.Add(message);
            return RedirectToAction("InBox");
        }
    }
}
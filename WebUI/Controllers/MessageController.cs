using Business.Abstract;
using Microsoft.AspNetCore.Mvc;
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
            var email = User.Identity.Name;
            var writerId = _writerService.GetList().Where(x => x.Email == email).Select(y => y.WriterId).FirstOrDefault();
            var values = _messageFkService.GetInboxListByWriter(writerId);
            return View(values);
        }

        public IActionResult Detail(int id)
        {
            var values = _messageFkService.GetById(id);
            ViewBag.senderName = _writerService.GetById((int)values.SenderId).Name;
            return View(values);
        }
    }
}
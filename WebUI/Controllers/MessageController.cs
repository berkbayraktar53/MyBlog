using Business.Abstract;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace WebUI.Controllers
{
    public class MessageController : Controller
    {
        private readonly IMessageFkService _messageFkService;

        public MessageController(IMessageFkService messageFkService)
        {
            _messageFkService = messageFkService;
        }

        public IActionResult InBox()
        {
            int id = 1;
            var values = _messageFkService.GetInboxListByWriter(id);
            return View(values);
        }

        public IActionResult Detail(int id)
        {
            var values = _messageFkService.GetById(id);
            return View(values);
        }
    }
}
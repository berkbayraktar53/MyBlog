using Business.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace WebUI.ViewComponents.Writer
{
    public class WriterMessageNotification : ViewComponent
    {
        private readonly IMessageFkService _messageFkService;

        public WriterMessageNotification(IMessageFkService messageFkService)
        {
            _messageFkService = messageFkService;
        }

        public IViewComponentResult Invoke()
        {
            int id = 1;
            var values = _messageFkService.GetInboxListByWriter(id);
            return View(values);
        }
    }
}
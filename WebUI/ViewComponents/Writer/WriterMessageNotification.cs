using Business.Abstract;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace WebUI.ViewComponents.Writer
{
    public class WriterMessageNotification : ViewComponent
    {
        private readonly IMessageFkService _messageFkService;
        private readonly IWriterService _writerService;

        public WriterMessageNotification(IMessageFkService messageFkService, IWriterService writerService)
        {
            _messageFkService = messageFkService;
            _writerService = writerService;
        }

        public IViewComponentResult Invoke()
        {
            var name = User.Identity.Name;
            var writerId = _writerService.GetList().Where(x => x.UserName == name).Select(y => y.Id).FirstOrDefault();
            var values = _messageFkService.GetInBoxListByWriter(writerId);
            return View(values);
        }
    }
}
﻿using Business.Abstract;
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
            var email = User.Identity.Name;
            var writerId = _writerService.GetList().Where(x => x.Email == email).Select(y => y.WriterId).FirstOrDefault();
            var values = _messageFkService.GetInboxListByWriter(writerId);
            return View(values);
        }
    }
}
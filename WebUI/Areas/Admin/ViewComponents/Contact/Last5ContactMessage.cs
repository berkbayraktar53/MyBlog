using Business.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace WebUI.Areas.Admin.ViewComponents.Contact
{
    public class Last5ContactMessage : ViewComponent
    {
        private readonly IContactService _contactService;

        public Last5ContactMessage(IContactService contactService)
        {
            _contactService = contactService;
        }

        public IViewComponentResult Invoke()
        {
            var values = _contactService.GetLast5ContactMessage();
            return View(values);
        }
    }
}
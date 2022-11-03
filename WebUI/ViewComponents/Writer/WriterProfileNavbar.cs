using Business.Abstract;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace WebUI.ViewComponents.Writer
{
    public class WriterProfileNavbar : ViewComponent
    {
        private readonly IWriterService _writerService;

        public WriterProfileNavbar(IWriterService writerService)
        {
            _writerService = writerService;
        }

        public IViewComponentResult Invoke()
        {
            var email = User.Identity.Name;
            var writerId = _writerService.GetList().Where(x => x.Email == email).Select(y => y.Id).FirstOrDefault();
            var values = _writerService.GetWriterById(writerId);
            return View(values);
        }
    }
}
using Business.Abstract;
using Business.Concrete;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Security.Claims;

namespace WebUI.ViewComponents.Writer
{
    public class WriterAboutOnDashboard : ViewComponent
    {
        private readonly IWriterService _writerService;

        public WriterAboutOnDashboard(IWriterService writerService)
        {
            _writerService = writerService;
        }

        public IViewComponentResult Invoke()
        {
            var userName = User.Identity.Name;
            var writerEmail = _writerService.GetList().Where(x => x.UserName == userName).Select(y => y.Email).FirstOrDefault();
            var writerId = _writerService.GetList().Where(x => x.Email == writerEmail).Select(y => y.Id).FirstOrDefault();
            var values = _writerService.GetWriterById(writerId);
            return View(values);
        }
    }
}
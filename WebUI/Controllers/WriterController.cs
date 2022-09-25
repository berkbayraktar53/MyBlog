using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace WebUI.Controllers
{
    public class WriterController : Controller
    {
        [AllowAnonymous]
        public IActionResult Index()
        {
            return View();
        }
    }
}
using Business.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace WebUI.Areas.Admin.ViewComponents.Writer
{
    public class Last10WriterList : ViewComponent
    {
        private readonly IUserService _userService;

        public Last10WriterList(IUserService userService)
        {
            _userService = userService;
        }

        public IViewComponentResult Invoke()
        {
            var values = _userService.GetLast10UserList();
            return View(values);
        }
    }
}
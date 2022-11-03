using Business.Abstract;
using Business.Concrete;
using Entities.Concrete;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace WebUI.ViewComponents.Blog
{
    public class WriterLastBlog : ViewComponent
    {
        private readonly UserManager<User> _userManager;
        private readonly IBlogService _blogService;

        public WriterLastBlog(UserManager<User> userManager, IBlogService blogService)
        {
            _userManager = userManager;
            _blogService = blogService;
        }

        public IViewComponentResult Invoke()
        {
            var userId = _userManager.FindByNameAsync(User.Identity.Name).Result.Id;
            var result = _blogService.GetListByUser(userId);
            return View(result);
        }
    }
}
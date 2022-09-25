using Business.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace WebUI.ViewComponents.Category
{
    public class CategoryList : ViewComponent
    {
        private readonly ICategoryService _categoryService;

        public CategoryList(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        public IViewComponentResult Invoke()
        {
            var result = _categoryService.GetList();
            return View(result);
        }
    }
}
using Business.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace WebUI.ViewComponents.Category
{
    public class CategoryListWriterDashboard : ViewComponent
    {
        private readonly ICategoryService _categoryService;

        public CategoryListWriterDashboard(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        public IViewComponentResult Invoke()
        {
            var values = _categoryService.GetListByActiveStatus();
            return View(values);
        }
    }
}
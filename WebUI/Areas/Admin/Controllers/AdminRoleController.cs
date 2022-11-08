using System.Linq;
using WebUI.Models;
using Business.Abstract;
using Entities.Concrete;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authorization;
using WebUI.Areas.Admin.Models;
using AspNetCoreHero.ToastNotification.Abstractions;

namespace WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class AdminRoleController : Controller
    {
        private readonly RoleManager<Role> _roleManager;
        private readonly INotyfService _notyfService;
        private readonly IRoleService _roleService;

        public AdminRoleController(RoleManager<Role> roleManager, INotyfService notyfService, IRoleService roleService)
        {
            _roleManager = roleManager;
            _notyfService = notyfService;
            _roleService = roleService;
        }

        public IActionResult Index()
        {
            var values = _roleService.GetList();
            return View(values);
        }

        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Add(RoleViewModel roleViewModel)
        {
            if (ModelState.IsValid)
            {
                Role role = new()
                {
                    Name = roleViewModel.RoleName,
                    NormalizedName=roleViewModel.RoleName
                };
                var result = await _roleManager.CreateAsync(role);
                if (result.Succeeded)
                {
                    _notyfService.Success("Rol Eklendi");
                    return RedirectToAction("Index", "AdminRole");
                }
                foreach (var item in result.Errors)
                {
                    ModelState.AddModelError("", item.Description);
                }
            }
            _notyfService.Error("Rol Eklenemedi");
            return View();
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var values = _roleManager.Roles.FirstOrDefault(x => x.Id == id);
            RoleUpdateViewModel model = new()
            {
                Id = values.Id,
                Name = values.Name
            };
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(RoleUpdateViewModel roleUpdateViewModel)
        {
            var values = _roleManager.Roles.Where(X => X.Id == roleUpdateViewModel.Id).FirstOrDefault();
            values.Name = roleUpdateViewModel.Name;
            var result = await _roleManager.UpdateAsync(values);
            if (result.Succeeded)
            {
                _notyfService.Success("Rol Güncellendi");
                return RedirectToAction("Index", "AdminRole");
            }
            _notyfService.Error("Rol Güncellenemedi");
            return View();
        }

        public async Task<IActionResult> Delete(int id)
        {
            var values = _roleManager.Roles.FirstOrDefault(X => X.Id == id);
            var result = await _roleManager.DeleteAsync(values);
            if (result.Succeeded)
            {
                _notyfService.Success("Rol Silindi");
                return RedirectToAction("Index", "AdminRole");
            }
            _notyfService.Error("Rol Silinemedi");
            return View(values);
        }
    }
}
using System.ComponentModel.DataAnnotations;

namespace WebUI.Areas.Admin.Models
{
    public class RoleViewModel
    {
        [Required(ErrorMessage = "Lütfen rol adı giriniz")]
        public string RoleName { get; set; }
    }
}
using System.ComponentModel.DataAnnotations;

namespace WebUI.Models
{
    public class AdminRoleViewModel
    {
        [Required(ErrorMessage = "Lütfen rol adı giriniz")]
        public string RoleName { get; set; }
    }
}
using System.ComponentModel.DataAnnotations;

namespace WebUI.Areas.Admin.Models
{
    public class ChangePasswordViewModel
    {
        [Required(ErrorMessage = "Lütfen mevcut şifrenizi giriniz")]
        public string CurrentPassword { get; set; }

        [Required(ErrorMessage = "Lütfen yeni şifrenizi giriniz")]
        public string NewPassword { get; set; }

        [Required(ErrorMessage = "Lütfen yeni şifrenizi tekrar giriniz")]
        public string RePassword { get; set; }
    }
}
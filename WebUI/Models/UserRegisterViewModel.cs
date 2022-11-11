using System.ComponentModel.DataAnnotations;

namespace WebUI.Models
{
    public class UserRegisterViewModel
    {
        [Required(ErrorMessage = "Lütfen adı soyadı giriniz")]
        public string FullName { get; set; }

        [Required(ErrorMessage = "Lütfen kullanıcı adı giriniz")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "Lütfen mail adresi giriniz")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Lütfen şifre giriniz")]
        public string Password { get; set; }

        [Compare("Password", ErrorMessage = "Şifreler birbiriyle uyuşmuyor")]
        public string ConfirmPassword { get; set; }
    }
}
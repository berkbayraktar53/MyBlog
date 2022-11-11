using System.ComponentModel.DataAnnotations;

namespace WebUI.Models
{
    public class UserUpdateViewModel
    {
        [Required(ErrorMessage = "Lütfen adı soyadı giriniz")]
        public string FullName { get; set; }

        [Required(ErrorMessage = "Lütfen kullanıcı adı giriniz")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "Lütfen mail adresi giriniz")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Lütfen resim ekleyiniz")]
        public string ImageUrl { get; set; }

        [Required(ErrorMessage = "Lütfen şifre giriniz")]
        public string Password { get; set; }
    }
}
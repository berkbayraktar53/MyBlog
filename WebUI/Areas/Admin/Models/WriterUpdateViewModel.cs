using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace WebUI.Areas.Admin.Models
{
    public class WriterUpdateViewModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Lütfen yazar resmi giriniz")]
        public string ImageUrl { get; set; }

        [Required(ErrorMessage = "Lütfen adı soyadı giriniz")]
        public string NameSurname { get; set; }

        [Required(ErrorMessage = "Lütfen mail adresi giriniz")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Lütfen kullanıcı adı giriniz")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "Lütfen şifre giriniz")]
        public string PasswordHash { get; set; }
    }
}
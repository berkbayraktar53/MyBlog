using System.ComponentModel.DataAnnotations;

namespace WebUI.Areas.Admin.Models
{
    public class RoleUpdateViewModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Lütfen rol adı giriniz")]
        public string Name { get; set; }
    }
}
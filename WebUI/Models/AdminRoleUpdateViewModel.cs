using System.ComponentModel.DataAnnotations;

namespace WebUI.Models
{
    public class AdminRoleUpdateViewModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Lütfen rol adı giriniz")]
        public string Name { get; set; }
    }
}
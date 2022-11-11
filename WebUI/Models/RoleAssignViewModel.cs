using System.ComponentModel.DataAnnotations;

namespace WebUI.Models
{
    public class RoleAssignViewModel
    {
        public int RoleId { get; set; }

        [Required(ErrorMessage = "Lütfen rol adı giriniz")]
        public string Name { get; set; }
        public bool Exists { get; set; }
    }
}
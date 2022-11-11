using Microsoft.AspNetCore.Http;

namespace WebUI.Models
{
    public class UserProfileImage
    {
        public int WriterId { get; set; }
        public IFormFile Image { get; set; }
        public string Name { get; set; }
        public string About { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public bool Status { get; set; }
    }
}
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;

namespace WebUI.Models
{
    public class WriterProfileImage
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
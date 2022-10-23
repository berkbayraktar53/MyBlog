﻿using System.ComponentModel.DataAnnotations;

namespace WebUI.Models
{
    public class UserLoginViewModel
    {
        [Required(ErrorMessage = "Lütfen kullanıcı adını giriniz")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "Lütfen şifrenizi giriniz")]
        public string Password { get; set; }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Database.Entities;
using System.ComponentModel.DataAnnotations;

namespace src.ViewModel
{

    public class LoginModel
    {
        [Required]
        public string Username { get; set; }
        [Required]
        public string Password { get; set; }
        [Compare(nameof(Password),ErrorMessage ="Confirm password not matched")]
        public string ConfirmPassword { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PinAPhoto.Models
{
    public class LoginModel
    {
        [StringLength(50, MinimumLength = 5, ErrorMessage = "Błędny login")]
        [Required(ErrorMessage = "Błędny login")]
        public string UserName { get; set; }

        [StringLength(30, MinimumLength = 8, ErrorMessage = "Hasło niepoprawne")]
        [Required(ErrorMessage = "Hasło niepoprawne")]
        public string Password { get; set; }

        public string ReturnUrl { get; set; } = "/";
    }
}

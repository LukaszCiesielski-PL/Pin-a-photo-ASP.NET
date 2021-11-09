using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;
using Projekt.Models;
using System.Collections.Generic;
using System;
namespace Projekt.Models
{
    public class User
    {

        public readonly Guid UID = Guid.NewGuid();

        [StringLength(30, MinimumLength = 5, ErrorMessage = "Twój login powinien posiadać minimum 5 znaków.")]
        [RegularExpression(@"^[A-Z]+[a-zA-Z0-9\s-_]*$", ErrorMessage = "Twój login powinien zaczynać się z WIELKIEJ LITERY. Dostępne znaki specjalne: ' -, _ '")]
        [Required(ErrorMessage = "Musisz podać login")]
        public string Login { get; set; }

        [RegularExpression(@"^\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*$", ErrorMessage = "Twój email jest błędny.")]
        [Required(ErrorMessage = "Musisz podać email")]
        public string Email { get; set; }

        [StringLength(30, MinimumLength = 8, ErrorMessage = "Twoje hasło powinno posiadać minimum 8 znaków.")]
        [RegularExpression(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[@$!%*?&])[A-Za-z\d@$!%*?&]{8,}$", ErrorMessage = "Twoje hasło powinno zawirać małe litery, duże litery, cyfry, znaki specjalne")]
        [Required(ErrorMessage = "Musisz podać hasło")]
        public string Password { get; set; }

        [StringLength(30, MinimumLength = 8, ErrorMessage = "Twoje hasło powinno posiadać minimum 8 znaków i zgadzać się z pierwotnym hasłem.")]
        [RegularExpression(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[@$!%*?&])[A-Za-z\d@$!%*?&]{8,}$", ErrorMessage = "Twoje hasło powinno zawirać małe litery, duże litery, cyfry, znaki specjalne i zgadzać się w pierwotnie wprowadzonym hasłem.")]
        [Required(ErrorMessage = "Musisz podać ponownie hasło")]
        public string RepeatPassword { get; set; }

       
    }
    
}

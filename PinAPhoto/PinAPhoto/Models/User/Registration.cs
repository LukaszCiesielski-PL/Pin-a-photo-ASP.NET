using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PinAPhoto.Models
{
    public class Registration
    {
        [RegularExpression(@"^\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*$", ErrorMessage = "Twój email jest błędny.")]
        [Required(ErrorMessage = "Musisz podać email")]
        public string Email { get; set; }

        [StringLength(50, MinimumLength = 5, ErrorMessage = "Podaj login, minimum 5 znaków")]
        //[RegularExpression(@"^[A-Z]+[a-zA-Z0-9\s-_]*$", ErrorMessage = "Dozwolone znaki A-Z a-z")]
        [Required(ErrorMessage = "Musisz podać login")]
        public string Name { get; set; }

        /*[StringLength(30, MinimumLength = 5)]
        [RegularExpression(@"^[A-Z]+[a-zA-Z0-9\s-_]*$", ErrorMessage = "Twój login powinien posiadać minimum 5 znaków, zaczynać się z WIELKIEJ LITERY. Dostępne znaki specjalne: ' -, _ '")]
        [Required(ErrorMessage = "Musisz podać login")]
        public string Login { get; set; }*/

        [StringLength(30, MinimumLength = 8)]
        [RegularExpression(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[@$!%*?&])[A-Za-z\d@$!%*?&]{8,}$", ErrorMessage = "Twoje hasło powinno zawierać 8 znaków, małe litery, duże litery, cyfry, znaki specjalne")]
        [Required(ErrorMessage = "Musisz podać hasło")]
        public string Password { get; set; }

        [StringLength(30, MinimumLength = 8)]
        [RegularExpression(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[@$!%*?&])[A-Za-z\d@$!%*?&]{8,}$", ErrorMessage = "Twoje hasło powinno zawierać zawierać 8 znaków, małe litery, duże litery, cyfry, znaki specjalne i zgadzać się w pierwotnie wprowadzonym hasłem.")]
        [Required(ErrorMessage = "Musisz podać ponownie hasło")]
        public string RepeatPassword { get; set; }

        public string ReturnUrl { get; set; } = "/";
    }
}

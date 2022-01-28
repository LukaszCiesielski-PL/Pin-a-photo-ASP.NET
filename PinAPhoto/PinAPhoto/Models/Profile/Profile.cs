using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PinAPhoto.Models.Profile
{
    public class Profile
    {
        [StringLength(50, MinimumLength = 5, ErrorMessage = "Podaj login, minimum 5 znaków")]
        public string Name { get; set; }
        [StringLength(100, MinimumLength = 5)]
        public string Description { get; set; }

        //public string UserAvatar { get; set; }


    }
}

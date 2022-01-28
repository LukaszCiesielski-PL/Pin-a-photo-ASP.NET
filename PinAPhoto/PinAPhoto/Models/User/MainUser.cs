using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace PinAPhoto.Models
{
    public class MainUser : IdentityUser
    {
        public MainUser() : base() { }

        
        public string Description { get; set; }
        //public string UserAvatar { get; set; }
        
    }
}

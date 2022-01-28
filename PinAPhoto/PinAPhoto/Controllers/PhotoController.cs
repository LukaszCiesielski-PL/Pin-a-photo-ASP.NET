using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PinAPhoto.Controllers
{
    public class PhotoController : Controller
    {
        public IActionResult AddPhoto()
        {
            return View();
        }
        
    }
}

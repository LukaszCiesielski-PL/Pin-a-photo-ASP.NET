using Microsoft.AspNetCore.Mvc;
using Projekt.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Projekt.Controllers
{
    [Route(template: "/api/v1/users")]
    public class RestPhotoController : Controller
    {
        [Route(template:"{id}")]
        public ActionResult<User> Get(int id)
        {
            return View();
        }
    }
}

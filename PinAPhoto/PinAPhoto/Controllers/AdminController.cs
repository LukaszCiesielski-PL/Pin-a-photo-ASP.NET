using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using PinAPhoto.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace PinAPhoto.Controllers
{
    public class AdminController : Controller
    {
        private UserManager<MainUser> userManager;
        private RoleManager<IdentityRole> roleManager;

        private IMainUserRepository userRepository;
        private ICrudMainUserRepository crudUser;

        public IActionResult Index()
        {
            return View();
        }
        public AdminController(ICrudMainUserRepository crudUser, IMainUserRepository userRepository,
                               UserManager<MainUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            this.crudUser = crudUser;
            this.userRepository = userRepository;
            this.userManager = userManager;
            this.roleManager = roleManager;
        }

        //[Authorize(Policy = "AdminAccess")]
        public IActionResult AllUsers()
        {
            return View(userRepository.MainUsers);
        }
        //[Authorize(Policy = "AdminAccess")]
        public IActionResult DeleteUser(string Name)
        {
            var usertoDelete = crudUser.Find(Name);
            if (usertoDelete is not null)
            {
                var currentUser = crudUser.Find(User.Identity.Name);
                if (usertoDelete.Id != currentUser.Id || !User.IsInRole("Admin"))
                    crudUser.Delete(Name);
            }
            return View("/Views/Admin/AllUsers.cshtml", userRepository.MainUsers);
        }
    }
}

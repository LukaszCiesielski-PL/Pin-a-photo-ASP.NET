using Microsoft.AspNetCore.Mvc;
using PinAPhoto.Models;
using PinAPhoto.Models.Profile;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace PinAPhoto.Controllers
{
    public class ProfileController : Controller
    {
        private IMainUserRepository _userRepository;
        private ICrudMainUserRepository _crudMainUserRepository;

        public ProfileController(ICrudMainUserRepository crudMainUserRepository, IMainUserRepository userRepository)
        {
            _crudMainUserRepository = crudMainUserRepository;
            _userRepository = userRepository;
        }


        public IActionResult UpdateProfile()
        {
            return View();
        }
        public IActionResult ShowProfile()
        {
            return View();
        }

        public IActionResult SaveChanges(SetInfoUser setInfoUser)
        {
            var user = _crudMainUserRepository.Find(User.Identity.Name);

            if (setInfoUser.Name != null)
            {
                user.UserName = setInfoUser.Name;
                user.NormalizedUserName = setInfoUser.Name;
            }
            if (setInfoUser.Description != null)
            {
                user.Description = setInfoUser.Description;
            }
            /*if (setInfoUser.UserAvatar != null)
            {
                user.UserAvatar = setInfoUser.UserAvatar;
            }*/
            _crudMainUserRepository.Update(user);

            return View("\\Views\\Profile\\ShowProfile.cshtml");


        }
       

        public IActionResult DeleteUser(string Name)
        {
            var usertoDelete = _crudMainUserRepository.Find(Name);
            if (usertoDelete is not null)
            {
                var currentUser = _crudMainUserRepository.Find(User.Identity.Name);
                if (usertoDelete.Id == currentUser.Id)
                    _crudMainUserRepository.Delete(Name);
            }
            return View("/Views/Home/Index.cshtml", _userRepository.MainUsers);
        }

    }
}
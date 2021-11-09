using Microsoft.AspNetCore.Mvc;
using Projekt.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Projekt.Controllers
{
    public class UserController : Controller
    {
        static List<User> Users = new List<User>()
        {
            new User()
            {    
                //Id = 1,
                Login = "Clukasz_99",
                Email = "ciesielski188@gmail.com",
                Password = "Genesis123!",
                RepeatPassword = "Genesis123!"
            },
            new User()
            {   
                //Id = 2,
                Login = "Clukasz_999",
                Email = "ciesielski1888@gmail.com",
                Password = "Genesis1233!",
                RepeatPassword = "Genesis1233!"
            }

        };
        //public static int counter = Users.Count;

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Add()
        {
            //counter++;
            return View();
        }

        public IActionResult AddUser(User user)
        {
            if (user.Password == user.RepeatPassword && ModelState.IsValid)
            {
                //user.Id = counter;
                Users.Add(user);
                return View("UserList", Users); 
            }            
            else
            {
                return View("Add");
            }


        }
        
        public IActionResult Delete(Guid Id)
        {
            var RemoveUser = Users.FirstOrDefault(el => Guid.Equals(Id, el.UID));
            if (RemoveUser != null)
                Users.Remove(RemoveUser);
            return View("UserList", Users);
        }

        public IActionResult Edit(User user)
        {
            return View("Add");
        }
    }
}

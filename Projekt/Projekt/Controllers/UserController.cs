using Microsoft.AspNetCore.Mvc;
using Projekt.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace Projekt.Controllers
{
   

    public class UserController : Controller
    {
        static List<User> Users = new List<User>()
        {
            

        };
        public static int counter = Users.Count;




        private IUserRepository repository;
        public UserController(IUserRepository repository)
        {
            this.repository = repository;
        }

        public IActionResult Index()
        {
            return View("UserList",repository.Users);
        }

        public IActionResult Add()
        {
            counter++;
            return View();
        }

        public IActionResult AddUser(User user)
        {
            if (user.Password == user.RepeatPassword && ModelState.IsValid)
            {
                user.id = counter;
                Users.Add(user);
                return View("UserList", Users); 
            }            
            else
            {
                return View("Add");
            }


        }
        
        public IActionResult Delete(int id)
        {
            // var RemoveUser = Users.FirstOrDefault(el => el.id == Id);
            // if (RemoveUser != null)
            //     Users.Remove(RemoveUser);

            var del = repository.Users.Remove(id).Entity;
            repository.SaveChanges();
            return View("UserList", repository.Users);
        }

        public IActionResult Edit(User user)
        {
            return View("Add");
        }
    }
}

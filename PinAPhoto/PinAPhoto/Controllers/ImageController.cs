﻿using Microsoft.AspNetCore.Mvc;
using PinAPhoto.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PinAPhoto.Controllers
{
    public class ImageController : Controller
    {
        static List<Image> Images = new List<Image>();

        public IActionResult Index()
        {
            return View();
        }
        public IActionResult AddForm()
        {
            return View();
        }
        public IActionResult AddImage(Image image)
        {
            if (ModelState.IsValid)
            {
                Images.Add(image);
                return View("ImageList", Images);
            }
            else
            {
                return View("AddForm");
            }
        }


        public IActionResult DeleteImage(Guid Id)
        {
            var itemToRemove = Images.FirstOrDefault(el => Guid.Equals(Id, el.GID));
            if (itemToRemove != null)
                Images.Remove(itemToRemove);
            return View("ImageList", Images);
        }

        public IActionResult EditForm(Guid Id)
        {
            var currentImage = Images.FirstOrDefault(el => Guid.Equals(Id, el.GID));
            return View("EditForm", currentImage);
        }

        public IActionResult EditImage(Image image, Guid Id)
        {
            if (ModelState.IsValid)
            {
                Images.Find(p => p.GID == Id).Title = image.Title;
                Images.Find(p => p.GID == Id).Description = image.Description;
                return View("ImageList", Images);
            }
            else
            {
                return View("ImageList", Images);
            }
        }


    }
}


using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PinAPhoto.Models
{
    public class Image
    {
        //public int Id;

        [Required(ErrorMessage = "Title is required")]
        [MinLength(3, ErrorMessage = "Title minimum length is 3")]
        [StringLength(100, ErrorMessage = "Title cannot be longer then 100")]
        public string Title { get; set; }

        /*private DateTime _UploadedDate = DateTime.Today; */
        public DateTime UploadDate = DateTime.Today;

        [FileExtensions(Extensions = "jpg,png")]
        [Required(ErrorMessage = "Image is required")]
        public string ImageData { get; set; }

        [StringLength(100, ErrorMessage = "Description cannot be longer then 100")]
        public string Description { get; set; }

        public readonly Guid GID = Guid.NewGuid();
    }
}

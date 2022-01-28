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
        [Key]
        public int Id { get; set; }
        public string Imagepath { get; set; }
    }
}

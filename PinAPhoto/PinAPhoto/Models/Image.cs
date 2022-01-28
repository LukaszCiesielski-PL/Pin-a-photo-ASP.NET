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
        [Required(ErrorMessage = "Podaj tytuł")]
        [MinLength(5, ErrorMessage = "Użyj minimum 5 znaków")]
        [StringLength(100, ErrorMessage = "Zbyt długa nazwa")]
        public string Title { get; set; }

        public DateTime UploadDate = DateTime.Today;

        [FileExtensions(Extensions = "jpg,png")]
        [Required(ErrorMessage = "Wybierz zdjęcie")]
        public string ImageData { get; set; }

        [StringLength(100, ErrorMessage = "Zbyt długi opis")]
        public string Description { get; set; }

        public readonly Guid GID = Guid.NewGuid();
    }
}

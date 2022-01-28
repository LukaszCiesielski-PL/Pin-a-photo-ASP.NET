﻿using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PinAPhoto.Models
{
    public interface IImageRepository
    {
        IQueryable<Image> Images { get; }
    }
    public class Image
    {
        public int id { get; set; }

        [Required(ErrorMessage = "Title is required")]
        [MinLength(3, ErrorMessage = "Title minimum length is 3")]
        [StringLength(100, ErrorMessage = "Title cannot be longer then 100")]
        public string Title { get; set; }

        //public DateTime UploadDate = DateTime.Today;

        [FileExtensions(Extensions = "jpg,png")]
        [Required(ErrorMessage = "Image is required")]
        public string ImageData { get; set; }

        [StringLength(100, ErrorMessage = "Description cannot be longer then 100")]
        public string Description { get; set; }

        
    }
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }
        public DbSet<Image> Images { get; set; }
    }

    public class EFImageRepository : IImageRepository
    {
        private ApplicationDbContext _applicationDbContext;
        public EFImageRepository(ApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }
        public IQueryable<Image> Images => _applicationDbContext.Images;
    }
}

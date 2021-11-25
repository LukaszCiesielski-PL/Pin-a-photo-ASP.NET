using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;
using Projekt.Models;
using System.Collections.Generic;
using System;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace Projekt.Models
{
    public interface IUserRepository
    {
        IQueryable<User> Users { get;}
        User Find(int id);
        User Delete(int id);
        User Add(User user);
    }

    

    public class ApplicationDbContext: DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }
        public DbSet<User> Users { get; set; }
    }

    public class EFUserRepository: IUserRepository
    {
        private ApplicationDbContext _applicationDbContext;
        public EFUserRepository(ApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }
        public User Find(int id)
        {
            return _applicationDbContext.Users.Find(id);
        }
        public User Delete(int id)
        {
            var user = _applicationDbContext.Users.Remove(Find(id)).Entity;
            _applicationDbContext.SaveChanges();
            return user;
        }
        

        public IQueryable<User> Users => _applicationDbContext.Users;


    }

    public class User
    {

        public int id {get; set;} 

        [StringLength(30, MinimumLength = 5, ErrorMessage = "Twój login powinien posiadać minimum 5 znaków.")]
        [RegularExpression(@"^[A-Z]+[a-zA-Z0-9\s-_]*$", ErrorMessage = "Twój login powinien zaczynać się z WIELKIEJ LITERY. Dostępne znaki specjalne: ' -, _ '")]
        [Required(ErrorMessage = "Musisz podać login")]
        public string Login { get; set; }

        [RegularExpression(@"^\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*$", ErrorMessage = "Twój email jest błędny.")]
        [Required(ErrorMessage = "Musisz podać email")]
        public string Email { get; set; }

        [StringLength(30, MinimumLength = 8, ErrorMessage = "Twoje hasło powinno posiadać minimum 8 znaków.")]
        [RegularExpression(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[@$!%*?&])[A-Za-z\d@$!%*?&]{8,}$", ErrorMessage = "Twoje hasło powinno zawirać małe litery, duże litery, cyfry, znaki specjalne")]
        [Required(ErrorMessage = "Musisz podać hasło")]
        public string Password { get; set; }

        [StringLength(30, MinimumLength = 8, ErrorMessage = "Twoje hasło powinno posiadać minimum 8 znaków i zgadzać się z pierwotnym hasłem.")]
        [RegularExpression(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[@$!%*?&])[A-Za-z\d@$!%*?&]{8,}$", ErrorMessage = "Twoje hasło powinno zawirać małe litery, duże litery, cyfry, znaki specjalne i zgadzać się w pierwotnie wprowadzonym hasłem.")]
        [Required(ErrorMessage = "Musisz podać ponownie hasło")]
        public string RepeatPassword { get; set; }

       
    }
    
}

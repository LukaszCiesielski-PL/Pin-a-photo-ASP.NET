using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace PinAPhoto.Models
{
    public class AppIdentityDbContext : IdentityDbContext<MainUser>
    {
        public AppIdentityDbContext(DbContextOptions<AppIdentityDbContext> options) : base(options){ }
        
        public DbSet<MainUser> MainUsers { get; set; }
    }

    public interface IMainUserRepository
    {
        IQueryable<MainUser> MainUsers { get; }
    }
    public interface ICrudMainUserRepository
    {
        
        MainUser Find(string UserName);
        IList<MainUser> FindAll();
        MainUser Delete(string Name);
        MainUser Update(MainUser mainUser);

    }
    public class EFUserRepository : IMainUserRepository
    {
        private AppIdentityDbContext _ApplicationDbContext;
        public EFUserRepository(AppIdentityDbContext ApplicationDbContext)
        {
            _ApplicationDbContext = ApplicationDbContext;
        }
        public IQueryable<MainUser> MainUsers => _ApplicationDbContext.MainUsers;
    }
    class CrudUserRepository : ICrudMainUserRepository
    {
        private AppIdentityDbContext _context;
        public CrudUserRepository(AppIdentityDbContext context)
        {
            _context = context;
        }
        public MainUser Find(string UserName)
        {
            return _context.MainUsers.Where(el => el.UserName == UserName).FirstOrDefault();
        }

       
        public MainUser Delete(string Name)
        {
            var user = _context.MainUsers.Where(e => e.UserName == Name).First();
            _context.Remove(user);
            _context.SaveChanges();
            return user;
        }
        public MainUser Update(MainUser mainUser)
        {
            var updates = _context.MainUsers.Update(mainUser).Entity;
            _context.SaveChanges();
            return updates;
        }
        public IList<MainUser> FindAll()
        {
            return _context.MainUsers.ToList();
        }


    }
}
       
    


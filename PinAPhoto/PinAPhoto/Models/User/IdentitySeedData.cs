using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PinAPhoto.Enums;
namespace PinAPhoto.Models
{
    public static class IdentitySeedData
    {
        private const string adminLogin = "Admin";
        private const string adminPassword = "Qazwsx123!";

        public static async void EnsurePopulated(IApplicationBuilder app)
        {
            using (var scope = app.ApplicationServices.CreateScope())
            {
                var userManager = (UserManager<MainUser>)scope.ServiceProvider.GetService(typeof(UserManager<MainUser>));
                var roleManager = (RoleManager<IdentityRole>)scope.ServiceProvider.GetRequiredService(typeof(RoleManager<IdentityRole>));

                IdentityResult roleResult;

                foreach (var roleName in Enum.GetValues(typeof(Roles)))
                {
                    var roleExist = await roleManager.RoleExistsAsync(roleName.ToString());
                    if (!roleExist)
                    {
                        roleResult = await roleManager.CreateAsync(new IdentityRole(roleName.ToString()));
                    }
                }

                MainUser adminUser = await userManager.FindByIdAsync(adminLogin);
                if (adminUser == null)
                {
                    adminUser = new MainUser()
                    {
                        UserName = adminLogin,
                    };
                    await userManager.CreateAsync(adminUser, adminPassword);
                }
                await userManager.AddToRoleAsync(adminUser, Roles.Admin.ToString()); 
            }
        }
    }
    
}



using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TazaFood_Core.IdentityModels;

namespace TazaFood_Repository.IdentityContext
{
    public static class IdentityDbContextSeed
    {
        public static async Task AppUserAsync(UserManager<AppUser> usermanger)
        {
            if (!usermanger.Users.Any())
            {
                var user = new AppUser()
                {
                    DisplayName = "mohamed atef",
                    UserName = "mohamed.atef",
                    Email = "admin@gmail.com",
                    PhoneNumber = "01156985081"
                };
            
                await usermanger.CreateAsync(user,"admin123");
            }
        }
    }
}

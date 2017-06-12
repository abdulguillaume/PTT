using System;
using System.Linq;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Identity;
using System.Security.Claims;
using System.Threading.Tasks;
using PersonalProjectPTT.Models;

namespace PersonalProjectPTT.Data
{
    public class SampleData
    {
        public async static Task Initialize(IServiceProvider serviceProvider)
        {
            var context = serviceProvider.GetService<ApplicationDbContext>();
            var userManager = serviceProvider.GetService<UserManager<ApplicationUser>>();

            // Ensure db
            context.Database.EnsureCreated();

            // Ensure Stephen (IsAdmin)
            var abdul = await userManager.FindByNameAsync("Stephen.Walther@CoderCamps.com");
            if (abdul == null)
            {
                // create user
                abdul = new ApplicationUser
                {
                    UserName = "abdulguillaume@gmail.com",
                    Email = "abdulguillaume@gmail.com"
                };
                await userManager.CreateAsync(abdul, "Secret123!");

                // add claims
                await userManager.AddClaimAsync(abdul, new Claim("IsAdmin", "true"));
            }

            // Ensure Mike (not IsAdmin)
            var other = await userManager.FindByNameAsync("other@any.any");
            if (other == null)
            {
                // create user
                other = new ApplicationUser
                {
                    UserName = "other@any.any",
                    Email = "other@any.any"
                };
                await userManager.CreateAsync(other, "Secret123!");
            }


        }

    }
}

using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using StudentHubApi1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudentHubApi1.Data
{
    public class SeedDatabase
    {
        public async static void Initialize(IServiceProvider serviceProvider)
        {
            var Context = serviceProvider.GetRequiredService<DbContext>();
            var UserManager = serviceProvider.GetRequiredService<UserManager<ApplicationUser>>();
            var RoleManager = serviceProvider.GetRequiredService<RoleManager<IdentityRole>>();

            Context.Database.EnsureCreated();
            string[] roleNames = { Roles.Admin, Roles.User};
            IdentityResult roleResult;

            foreach (var roleName in roleNames)
            {
                var roleExist = await RoleManager.RoleExistsAsync(roleName);
                if (!roleExist)
                {
                    //create the roles and seed them to the database: Question 1  
                    roleResult = await RoleManager.CreateAsync(new IdentityRole(roleName));
                }
            }
            if (!Context.Users.Any())
            {
                ApplicationUser user = new ApplicationUser
                {
                    Id = Guid.NewGuid().ToString(),
                    Email = "DefaultEmail@Email.com",
                    UserName = "Anonymous",
                    PhoneNumber = "08136112263",
                    SecurityStamp = Guid.NewGuid().ToString()
                };
                await UserManager.CreateAsync(user, "Random123$");
                await UserManager.AddToRoleAsync(user, Roles.Admin);
            }
        }
    }
}

using MassageStudioApp.Data;
using MassageStudioApp.Entities;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MassageStudioApp.Infrastructure
{
    public static class ApplicationBuilderExtension
    {
        public static async Task<IApplicationBuilder> PrepareDatabase(this IApplicationBuilder app)
        {
            using var serviceScope = app.ApplicationServices.CreateScope();

            var services = serviceScope.ServiceProvider;

            await RoleSeeder(services);
            await SeedAdministrator(services);

            var data = serviceScope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
            SeedCategories(data);

            return app;
        }
        private static void SeedCategories(ApplicationDbContext data)
        {
            if (data.Categories.Any())
            {
                return;
            }
            data.Categories.AddRange(new[]
            {
                new Category {Name="Back massage", Description="maslo ot avocado", Price=60.00m},
                new Category {Name="Full body massage", Description="maslo ot avocado", Price=90.00m},
                new Category {Name="Lowerbody massage", Description="maslo ot avocado", Price=65.00m},
                new Category {Name="Upperbody massage", Description="maslo ot avocado", Price=60.00m},
                new Category {Name="Face massage", Description="maslo ot avocado", Price=40.00m},
                new Category {Name="Feet massage", Description="maslo ot avocado", Price=50.00m},
            });
            data.SaveChanges();
        }

        private static async Task RoleSeeder(IServiceProvider serviceProvider)
        {
            var roleManager = serviceProvider.GetRequiredService<RoleManager<IdentityRole>>();
            string[] roleNames = { "Administrator", "Client", "Employee" };
            IdentityResult roleResult;
            foreach (var role in roleNames)
            {
                var roleExist = await roleManager.RoleExistsAsync(role);
                if (!roleExist)
                {
                    roleResult = await roleManager.CreateAsync(new IdentityRole(role));
                }
            }
        }

        private static async Task SeedAdministrator(IServiceProvider serviceProvider)
        {
            var userManager = serviceProvider.GetRequiredService<UserManager<ApplicationUser>>();
            if (await userManager.FindByNameAsync("admin") == null)
            {
                ApplicationUser user = new ApplicationUser();
                user.UserName = "admin";
                user.Email = "admin@admin.com";

                var result = await userManager.CreateAsync(user, "123!@#qweQWE");

                if (result.Succeeded)
                {
                    userManager.AddToRoleAsync(user, "Administrator").Wait();
                }
            }
        }
    }
}

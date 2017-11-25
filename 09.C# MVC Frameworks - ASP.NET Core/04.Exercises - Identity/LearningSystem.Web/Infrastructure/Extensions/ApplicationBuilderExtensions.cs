namespace LearningSystem.Web.Infrastructure.Extensions
{
    using Constants;
    using Data;
    using Data.Models;
    using Microsoft.AspNetCore.Builder;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.DependencyInjection;
    using System;
    using System.Threading.Tasks;

    public static class ApplicationBuilderExtensions
    {
        public static IApplicationBuilder UseDatabaseMigration(this IApplicationBuilder app)
        {
            using (var serviceScope = app.ApplicationServices.GetRequiredService<IServiceScopeFactory>().CreateScope())
            {
                serviceScope.ServiceProvider.GetService<LearningSystemDbContext>().Database.Migrate();

                var userManager = serviceScope.ServiceProvider.GetService<UserManager<User>>();
                var roleManager = serviceScope.ServiceProvider.GetService<RoleManager<IdentityRole>>();

                Task
                    .Run(async () =>
                    {
                        var adminName = WebConstants.AdministratorRoleName;
                        var trainerName = WebConstants.TrainerRoleName;
                        var blogAuthorName = WebConstants.BlogAuthorRoleName;

                        var allRoles = new[]
                        {
                            adminName,
                            trainerName,
                            blogAuthorName
                        };

                        foreach (var role in allRoles)
                        {
                            var roleExist = await roleManager.RoleExistsAsync(role);

                            if (!roleExist)
                            {
                                await roleManager.CreateAsync(new IdentityRole
                                {
                                    Name = role
                                });
                            }
                        }

                        var userName = "admin@admin.bg";

                        var adminUser = await userManager.FindByEmailAsync(userName);

                        if (adminUser == null)
                        {
                            adminUser = new User
                            {
                                UserName = "Admin",
                                Email = userName,
                                Birthdate = DateTime.UtcNow,
                                SecurityStamp = "Som3RandomValue"
                            };

                            await userManager.CreateAsync(adminUser, "Admin12");

                            await userManager.AddToRoleAsync(adminUser, adminName);
                        }
                    })
                    .Wait();
            }
            return app;
        }
    }
}
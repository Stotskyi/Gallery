using GalleryAPI.Db;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace SportsStore.Models
{
    public static class IdentitySeedData
    {
        private const string owner = "Admin";
        private const string ownerPassword = "Secret123$";
        public static async void EnsurePopulated(IApplicationBuilder app)
        {
            ApplicationContext context = app.ApplicationServices
                .CreateScope().ServiceProvider
                .GetRequiredService<ApplicationContext>();
            if (context.Database.GetPendingMigrations().Any())
            {
                context.Database.Migrate();
            }
            UserManager<IdentityUser> userManager = app.ApplicationServices
                .CreateScope().ServiceProvider
                .GetRequiredService<UserManager<IdentityUser>>();
            IdentityUser user = (await userManager.FindByNameAsync(owner));
            if (user == null)
            {
                user = new IdentityUser("Owner");
                user.Email = "owner@gmail.com";
                user.PhoneNumber = "0934335443";
                await userManager.CreateAsync(user, ownerPassword);
            }
        }
    }
}
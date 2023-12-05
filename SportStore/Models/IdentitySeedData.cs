using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace SportStore.Models
{
    public class IdentitySeedData
    {
        private const string UserName = "Admin";
        private const string PassWord = "Admin@123";

        public static async void EnsurePopulated(IApplicationBuilder app)
        {
            AppIdentityDbContext context = app.ApplicationServices
                .CreateScope().ServiceProvider
                .GetRequiredService<AppIdentityDbContext>();
            if (context.Database.GetPendingMigrations().Any())
            {
                context.Database.Migrate();
            }

            UserManager<IdentityUser> userManager = app.ApplicationServices
                .CreateScope().ServiceProvider
                .GetRequiredService<UserManager<IdentityUser>>();
            IdentityUser user = await userManager.FindByNameAsync(UserName);
            if (user == null)
            {
                user = new IdentityUser("Admin");
                user.Email = "example@gmail.com";
                user.PhoneNumber = "555-1234";
                await userManager.CreateAsync(user, PassWord);
            }
        }
    }
}

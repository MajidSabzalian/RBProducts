using Microsoft.AspNetCore.Identity;

namespace RBProducts.Endpoint.WebAPI.Middlewares
{
    public static class DefaultIdentityExtenstions
    {
        public static async Task UseDefaultIdentity(this WebApplication App, IConfiguration configuration)
        {
            using var scope = App.Services.CreateScope();
            var roleManager = scope.ServiceProvider.GetService(typeof(RoleManager<IdentityRole>)) as RoleManager<IdentityRole>;
            var roles = configuration.GetSection("Roles").Get<List<string>>() ?? new List<string>();
            if (roleManager != null)
            {
                foreach (var role in roles)
                {
                    if (!await roleManager.RoleExistsAsync(role)) { await roleManager.CreateAsync(new IdentityRole(role)); }
                }
            }
            else
            {
                throw new Exception("Your Role Manager Not Found");
            }

            // Create Default User To Database 
            var userManager = scope.ServiceProvider.GetService(typeof(UserManager<IdentityUser>)) as UserManager<IdentityUser>;
            if (userManager != null)
            {
                {
                    var user = new IdentityUser() { UserName = "admin", Email = "a@a.com" };
                    IdentityResult chkUser = await userManager.CreateAsync(user, "Aa123456@" /* default password */);
                    if (chkUser.Succeeded)
                    {
                        var result1 = await userManager.AddToRoleAsync(user, "Admin");
                    }
                }
                {
                    var user = new IdentityUser() { UserName = "user", Email = "u@a.com" };
                    IdentityResult chkUser = await userManager.CreateAsync(user, "Aa123456@" /* default password */);
                    if (chkUser.Succeeded)
                    {
                        var result1 = await userManager.AddToRoleAsync(user, "Admin");
                    }
                }
            }
            else
            {
                throw new Exception("Your User Manager Not Found");
            }
        }
    }
}

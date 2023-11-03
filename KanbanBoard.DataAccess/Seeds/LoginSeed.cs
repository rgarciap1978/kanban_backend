using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;

namespace KanbanBoard.DataAccess.Seeds
{
    public static class LoginSeed
    {
        public static async Task Seed(IServiceProvider service)
        {
            var userManager = service.GetRequiredService<UserManager<KanbanBoardLoginIdentity>>();

            var roleManager = service.GetRequiredService<RoleManager<IdentityRole>>();

            var adminRole = new IdentityRole("ADMIN");
            var leadRole = new IdentityRole("LEAD");
            var devRole = new IdentityRole("DEV");
            var qaRole = new IdentityRole("QA");

            if (!await roleManager.RoleExistsAsync("ADMIN"))
                await roleManager.CreateAsync(adminRole);

            if (!await roleManager.RoleExistsAsync("LEAD"))
                await roleManager.CreateAsync(leadRole);

            if (!await roleManager.RoleExistsAsync("DEV"))
                await roleManager.CreateAsync(devRole);

            if (!await roleManager.RoleExistsAsync("QA"))
                await roleManager.CreateAsync(qaRole);

            var adminUser = new KanbanBoardLoginIdentity
            {
                FirstName="Administrator",
                LastName="",
                Email = "garciap.robertof@gmail.com",
                UserName = "garciap.robertof@gmail.com",
                EmailConfirmed = true
            };

            var result = await userManager.CreateAsync(adminUser, "P1$$w0rD");
            if(result.Succeeded)
            {
                adminUser=await userManager.FindByEmailAsync(adminUser.Email);
                if (adminUser != null)
                    await userManager.AddToRoleAsync(adminUser, "ADMIN");
            }
        }
    }
}

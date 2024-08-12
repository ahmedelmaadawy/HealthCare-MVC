using Microsoft.AspNetCore.Identity;

namespace HealthCare.Presentaion
{

    public class AppDbIntializer
    {
        public static async Task SeedRolesAsync(IApplicationBuilder applicationBuilder)
        {
            using (var serviceScope = applicationBuilder.ApplicationServices.CreateScope())
            {
                //Roles
                var roleManager = serviceScope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();
                if (!await roleManager.RoleExistsAsync("Admin"))
                    await roleManager.CreateAsync(new IdentityRole("Admin"));
                if (!await roleManager.RoleExistsAsync("Doctor"))
                    await roleManager.CreateAsync(new IdentityRole("Doctor"));
                if (!await roleManager.RoleExistsAsync("Patient"))
                    await roleManager.CreateAsync(new IdentityRole("Patient"));

            }
        }
    }
}



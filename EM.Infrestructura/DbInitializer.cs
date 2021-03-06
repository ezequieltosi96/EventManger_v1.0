using EM.Dominio.Identity;
using Microsoft.AspNetCore.Identity;

namespace EM.Infrestructura
{
    public static class DbInitializer
    {
        public static void SeedAdminUser(UserManager<AppUser> userManager, RoleManager<AppRole> roleManager)
        {
            if (userManager.FindByEmailAsync("admin@eventmanager.com").Result == null)
            {
                var user = new AppUser()
                {
                    UserName = "admin@eventmanager.com",
                    Email = "admin@eventmanager.com",
                };

                var result = userManager.CreateAsync(user, "EventManager").Result;

                if (result.Succeeded)
                {
                    if (roleManager.FindByNameAsync("Admin").Result == null)
                    {
                        var role = new AppRole()
                        {
                            Name = "Admin",
                        };

                        roleManager.CreateAsync(role).Wait();
                    }

                    userManager.AddToRoleAsync(user, "Admin").Wait();
                }
            }
        }

        public static void SeedRoles(RoleManager<AppRole> roleManager)
        {
            if (roleManager.FindByNameAsync("Admin").Result == null)
            {
                var role = new AppRole()
                {
                    Name = "Admin",
                };

                roleManager.CreateAsync(role).Wait();
            }
            if (roleManager.FindByNameAsync("Cliente").Result == null)
            {
                var role = new AppRole()
                {
                    Name = "Cliente",
                };

                roleManager.CreateAsync(role).Wait();
            }
            if (roleManager.FindByNameAsync("Empresa").Result == null)
            {
                var role = new AppRole()
                {
                    Name = "Empresa",
                };

                roleManager.CreateAsync(role).Wait();
            }
        }
    }
}

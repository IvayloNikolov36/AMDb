namespace AMDb.Web.Infrastructure.Extensions
{
    using AMDb.Data;
    using AMDb.DataModels;
    using Microsoft.AspNetCore.Builder;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.Extensions.DependencyInjection;
    using System.Threading.Tasks;
    using static ProjectConstants;

    public static class AppBuilderExtension
    {
        private static readonly IdentityRole[] roles =
        {
            new IdentityRole(AdminRole)
        };

        public static async void SeedDatabase(this IApplicationBuilder app)
        {
            var serviceFactory = app.ApplicationServices.GetRequiredService<IServiceScopeFactory>();
            var scope = serviceFactory.CreateScope();

            using (scope)
            {
                var roleManager = scope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();
                var userManager = scope.ServiceProvider.GetRequiredService<UserManager<User>>();
                var db = scope.ServiceProvider.GetRequiredService<AMDbContext>();

                await CreateRoles(roleManager);

                //create admin
                await CreateUser(userManager, AdminUserName, AdminEmail, DefaultAdminPassword, AdminRole);
            }
        }

        private static async Task CreateUser(UserManager<User> userManager, string userName, string email, string defaultPassword, string role)
        {
            var user = await userManager.FindByNameAsync(userName);

            if (user == null)
            {
                user = new User
                {
                    UserName = userName,
                    Email = email,
                    FirstName = AdminUserName,
                    LastName = AdminUserName
                };

                await userManager.CreateAsync(user, defaultPassword);
                await userManager.AddToRoleAsync(user, role);
            }
        }

        private static async Task CreateRoles(RoleManager<IdentityRole> roleManager)
        {
            foreach (var role in roles)
            {
                if (!await roleManager.RoleExistsAsync(role.Name))
                {
                    await roleManager.CreateAsync(role);
                }
            }
        }

    }
}

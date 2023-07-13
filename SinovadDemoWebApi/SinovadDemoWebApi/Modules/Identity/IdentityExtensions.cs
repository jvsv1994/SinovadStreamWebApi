using Generic.Core.Models;
using Microsoft.AspNetCore.Identity;
using SinovadDemo.Domain.Entities;

namespace SinovadDemoWebApi.Modules.Identity
{
    public static class IdentityExtensions
    {
        public static IServiceCollection AddIdentity(this IServiceCollection services)
        {
            IdentityBuilder builder = services.AddIdentityCore<User>();
            builder = new IdentityBuilder(builder.UserType, typeof(Role), builder.Services);
            builder.AddEntityFrameworkStores<ApplicationDbContext>();
            builder.AddDefaultTokenProviders();
            builder.AddRoleManager<RoleManager<Role>>();
            builder.AddSignInManager<SignInManager<User>>();
            services.Configure<IdentityOptions>(options =>
                {
                    options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(1);
                    options.Lockout.MaxFailedAccessAttempts = 3;
                }
            );   
            return services;
        }
    }
}

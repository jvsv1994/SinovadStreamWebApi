using Microsoft.AspNetCore.Identity;
using SinovadDemo.Domain.Entities;

namespace SinovadDemoWebApi.Modules.Identity
{
    public static class IdentityExtensions
    {
        public static IServiceCollection AddIdentity(this IServiceCollection services)
        {

            services.AddIdentity<IdentityUser, IdentityRole>().AddEntityFrameworkStores<ApplicationDbContext>().AddDefaultTokenProviders();
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

using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SinovadDemo.Application.Interface.Persistence;
using SinovadDemo.Domain.Entities;
using SinovadDemo.Persistence.Contexts;
using SinovadDemo.Persistence.Interceptors;
using SinovadDemo.Persistence.Repositories;

namespace SinovadDemo.Persistence
{
    public static class ConfigureServices
    {
        public static IServiceCollection AddPersistenceServices(this IServiceCollection services,IConfiguration configuration)
        {
            services.AddSingleton<DapperContext>();
            services.AddScoped<AuditableEntitySaveChangesInterceptor>();
            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("DefaultConnection"),
                builder=>builder.MigrationsAssembly(typeof(ApplicationDbContext).Assembly.FullName))
            );
            services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            return services;
        }

    }
}

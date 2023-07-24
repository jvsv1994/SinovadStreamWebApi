using SinovadDemo.Application.Configuration;
using SinovadDemo.Application.Shared;
using SinovadDemo.Transversal.Common;
using SinovadDemo.Transversal.Logger;

namespace SinovadDemoWebApi.Modules.Injection
{
    public static class InjectionExtensions
    {
        public static IServiceCollection AddInjection(this IServiceCollection services, IConfiguration configuration)
        {

            services.AddLogging();
            services.AddScoped(typeof(IAppLogger<>), typeof(LoggerAdapter<>));
            services.Configure<MyConfig>(configuration);
            return services;
        }

    }
}

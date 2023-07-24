using Microsoft.Extensions.DependencyInjection;
using SinovadDemo.Application.Interface.Infrastructure;
using SinovadDemo.Infrastructure.EmailSender;
using SinovadDemo.Infrastructure.Imdb;
using SinovadDemo.Infrastructure.Tmdb;

namespace SinovadDemo.Infrastructure
{
    public static class ConfigureServices
    {
        public static IServiceCollection AddInfrastructureServices(this IServiceCollection services)
        {
            services.AddScoped<IEmailSenderService, EmailSenderService>();
            services.AddScoped<ITmdbService, TmdbService>();
            services.AddScoped<IImdbService, ImdbService>();
            return services;
        }

    }
}
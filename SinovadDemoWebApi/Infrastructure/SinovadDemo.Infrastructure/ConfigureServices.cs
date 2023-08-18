using Firebase.Auth;
using Firebase.Auth.Providers;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SinovadDemo.Application.Interface.Infrastructure;
using SinovadDemo.Infrastructure.EmailSender;
using SinovadDemo.Infrastructure.Firebase;
using SinovadDemo.Infrastructure.Imdb;
using SinovadDemo.Infrastructure.Tmdb;

namespace SinovadDemo.Infrastructure
{
    public static class ConfigureServices
    {
        public static IServiceCollection AddInfrastructureServices(this IServiceCollection services,IConfiguration configuration)
        {
            var firebaseProjectName = configuration["FirebaseProjectId"]!=null?configuration["FirebaseProjectId"].ToString():"";
            var firebaseApiKey = configuration["FirebaseApiKey"]!=null?configuration["FirebaseApiKey"].ToString():"";
            services.AddSingleton(new FirebaseAuthClient(new FirebaseAuthConfig
            {
                ApiKey = firebaseApiKey,
                AuthDomain = $"{firebaseProjectName}.firebaseapp.com",
                Providers = new FirebaseAuthProvider[]
                {
                    new EmailProvider(),
                    new GoogleProvider()
                }
            }));
            services.AddSingleton<IFirebaseAuthService, FirebaseAuthService>();
            services.AddScoped<IEmailSenderService, EmailSenderService>();
            services.AddScoped<ITmdbService, TmdbService>();
            services.AddScoped<IImdbService, ImdbService>();
            return services;
        }

    }
}
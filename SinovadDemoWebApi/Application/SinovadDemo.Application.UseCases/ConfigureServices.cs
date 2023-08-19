using Microsoft.Extensions.DependencyInjection;
using SinovadDemo.Application.Interface.UseCases;
using SinovadDemo.Application.Shared;
using SinovadDemo.Application.UseCases.Authentication;
using SinovadDemo.Application.UseCases.Catalogs;
using SinovadDemo.Application.UseCases.Documents;
using SinovadDemo.Application.UseCases.Episodes;
using SinovadDemo.Application.UseCases.Genres;
using SinovadDemo.Application.UseCases.MediaServers;
using SinovadDemo.Application.UseCases.Movies;
using SinovadDemo.Application.UseCases.Profiles;
using SinovadDemo.Application.UseCases.Roles;
using SinovadDemo.Application.UseCases.Seasons;
using SinovadDemo.Application.UseCases.TvSeries;
using SinovadDemo.Application.UseCases.Users;
using SinovadDemo.Application.Validator;
using System.Reflection;

namespace SinovadDemo.Application.UseCases
{
    public static  class ConfigureServices
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            services.AddAutoMapper(Assembly.GetExecutingAssembly());
            //scoped services
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IMenuService, MenuService>();
            services.AddScoped<IRoleService, RoleService>();
            services.AddScoped<IMediaServerService, MediaServerService>();
            services.AddScoped<IMovieService, MovieService>();
            services.AddScoped<ITvSerieService, TvSerieService>();
            services.AddScoped<ISeasonService, SeasonService>();
            services.AddScoped<IEpisodeService, EpisodeService>();
            services.AddScoped<IGenreService, GenreService>();
            services.AddScoped<ICatalogService, CatalogService>();
            services.AddScoped<IProfileService, ProfileService>();
            services.AddScoped<IDocumentService, DocumentService>();
            services.AddScoped<IAuthenticationService, AuthenticationService>();
            services.AddScoped<SharedService>();

            //validators
            services.AddTransient<AccessUserDtoValidator>();

            return services;
        }
    }
}

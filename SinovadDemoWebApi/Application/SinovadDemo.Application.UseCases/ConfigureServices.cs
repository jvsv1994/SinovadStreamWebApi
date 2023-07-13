using Microsoft.Extensions.DependencyInjection;
using SinovadDemo.Application.Builder;
using SinovadDemo.Application.Interface.UseCases;
using SinovadDemo.Application.Shared;
using SinovadDemo.Application.UseCases.Users;
using SinovadDemo.Application.UseCases.MediaServers;
using SinovadDemo.Application.UseCases.Storages;
using SinovadDemo.Application.UseCases.Catalogs;
using SinovadDemo.Application.UseCases.Episodes;
using SinovadDemo.Application.UseCases.Genres;
using SinovadDemo.Application.UseCases.Movies;
using SinovadDemo.Application.UseCases.Profiles;
using SinovadDemo.Application.UseCases.Seasons;
using SinovadDemo.Application.UseCases.TranscoderSetting;
using SinovadDemo.Application.UseCases.TranscodingProcesses;
using SinovadDemo.Application.UseCases.TvSeries;
using SinovadDemo.Application.UseCases.Videos;
using SinovadDemo.Application.Validator;

namespace SinovadDemo.Application.UseCases
{
    public static  class ConfigureServices
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            //scoped services
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IMenuService, MenuService>();
            services.AddScoped<IMediaServerService, MediaServerService>();
            services.AddScoped<IStorageService, StorageService>();
            services.AddScoped<IMovieService, MovieService>();
            services.AddScoped<ITvSerieService, TvSerieService>();
            services.AddScoped<ISeasonService, SeasonService>();
            services.AddScoped<IEpisodeService, EpisodeService>();
            services.AddScoped<IGenreService, GenreService>();
            services.AddScoped<ICatalogService, CatalogService>();
            services.AddScoped<IProfileService, ProfileService>();
            services.AddScoped<ITranscoderSettingsService, TranscoderSettingsService>();
            services.AddScoped<IVideoService, VideoService>();
            services.AddScoped<ITranscodingProcessService, TranscodingProcessService>();
            services.AddScoped<SharedService>();

            //validators
            services.AddTransient<AccessUserDtoValidator>();

            // singleton services
            services.AddSingleton<SearchMediaLogBuilder>();

            return services;
        }
    }
}

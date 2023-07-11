using Microsoft.Extensions.DependencyInjection;
using SinovadDemo.Application.Builder;
using SinovadDemo.Application.Interface.UseCases;
using SinovadDemo.Application.Shared;
using SinovadDemo.Application.UseCases.Accounts;
using SinovadDemo.Application.UseCases.AccountServers;
using SinovadDemo.Application.UseCases.AccountStorages;
using SinovadDemo.Application.UseCases.Catalogs;
using SinovadDemo.Application.UseCases.Episodes;
using SinovadDemo.Application.UseCases.Genres;
using SinovadDemo.Application.UseCases.Movies;
using SinovadDemo.Application.UseCases.Profiles;
using SinovadDemo.Application.UseCases.Seasons;
using SinovadDemo.Application.UseCases.TranscodeSettings;
using SinovadDemo.Application.UseCases.TranscodeVideoProcesses;
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
            services.AddScoped<IAccountService, AccountService>();
            services.AddScoped<IAccountServerService, AccountServerService>();
            services.AddScoped<IAccountStorageService, AccountStorageService>();
            services.AddScoped<IMovieService, MovieService>();
            services.AddScoped<ITvSerieService, TvSerieService>();
            services.AddScoped<ISeasonService, SeasonService>();
            services.AddScoped<IEpisodeService, EpisodeService>();
            services.AddScoped<IGenreService, GenreService>();
            services.AddScoped<ICatalogService, CatalogService>();
            services.AddScoped<IProfileService, ProfileService>();
            services.AddScoped<ITranscodeSettingService, TranscodeSettingService>();
            services.AddScoped<IVideoService, VideoService>();
            services.AddScoped<ITranscodeVideoProcessService, TranscodeVideoProcessService>();
            services.AddScoped<SharedService>();

            //validators
            services.AddTransient<AccessUserDtoValidator>();

            // singleton services
            services.AddSingleton<SearchMediaLogBuilder>();

            return services;
        }
    }
}

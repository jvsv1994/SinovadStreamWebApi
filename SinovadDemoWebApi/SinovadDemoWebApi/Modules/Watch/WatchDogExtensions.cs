using WatchDog;
using WatchDog.src.Enums;

namespace SinovadDemoWebApi.Modules.Watch
{
    public static class WatchDogExtensions
    {
        public static IServiceCollection AddWatchLog(this IServiceCollection services,IConfiguration configuration)
        {
            services.AddWatchDogServices(opt =>
            {
                opt.SetExternalDbConnString=configuration.GetConnectionString("DefaultConnection");
                opt.DbDriverOption = WatchDogDbDriverEnum.MSSQL;
                opt.IsAutoClear=true;
                opt.ClearTimeSchedule = WatchDogAutoClearScheduleEnum.Monthly;
            });
            return services;
        }

    }
}

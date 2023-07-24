using System.Reflection;
using SinovadDemo.Application.Configuration;
using SinovadDemo.Transversal.Logger;

namespace SinovadDemoWebApi.Modules.Logger
{
    public static  class LoggerExtensions
    {
        public static IServiceProvider AddLogger(this IServiceProvider services,IConfiguration configuration,string environmentName= "Test")
        {
            var myConfig = configuration.Get<MyConfig>();

            var lf = services.GetRequiredService<ILoggerFactory>();
            lf.AddSyslog(myConfig.PaperTrailSettings.Host,myConfig.PaperTrailSettings.Port,Assembly.GetEntryAssembly().GetName().Name, environmentName);
            return services;
        }

    }
}

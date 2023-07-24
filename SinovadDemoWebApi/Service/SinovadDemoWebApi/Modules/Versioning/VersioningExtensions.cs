using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Versioning;

namespace SinovadDemoWebApi.Modules.Versioning
{
    public static class VersioningExtensions
    {
        public static IServiceCollection AddVersioning(this IServiceCollection services)
        {
            services.AddApiVersioning(o =>
            {
                o.DefaultApiVersion = new ApiVersion(1, 0);
                o.AssumeDefaultVersionWhenUnspecified = true;
                o.ReportApiVersions = true;
                //O.ApiVersionReader = new QueryStringApiVersionReader("api-version");
                //o.ApiVersionReader = new HeaderApiVersionReader("x-version");
                o.ApiVersionReader = new UrlSegmentApiVersionReader();
            });
            services.AddVersionedApiExplorer(options =>
            {
                options.GroupNameFormat = "'v'VVV";
                options.SubstituteApiVersionInUrl = true;
            });
            return services;
        }

    }
}

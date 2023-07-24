using Microsoft.AspNetCore.Mvc.ApiExplorer;
using Microsoft.Extensions.Options;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace SinovadDemoWebApi.Modules.Swagger
{
    public class ConfigureSwaggerOptions:IConfigureOptions<SwaggerGenOptions>
    {
        readonly IApiVersionDescriptionProvider provider;
        public ConfigureSwaggerOptions(IApiVersionDescriptionProvider provider)=>this.provider = provider;

        public void Configure(SwaggerGenOptions options)
        {
            // add a swagger document for each discovered API version
            //note : you might choose to skip or document deprecated API versions differently
            foreach(var description in provider.ApiVersionDescriptions)
            {
                options.SwaggerDoc(description.GroupName,CreateInfoForApiVersion(description));
            }
        }

        static OpenApiInfo CreateInfoForApiVersion(ApiVersionDescription description)
        {
            var info = new OpenApiInfo
            {
                Version = description.ApiVersion.ToString(),
                Title = "Sinovad Web Api",
                Description = "A simple example ASP.NET Core Web Api",
                TermsOfService = new Uri("http://www.sinovad.com"),
                Contact = new OpenApiContact
                {
                    Name = "Jorge Solis Vega",
                    Email = "jvsv1994@gmail.com",
                    Url = new Uri("http://www.sinovad.com")
                },
                License = new OpenApiLicense
                {
                    Name = "License",
                    Url = new Uri("http://www.sinovad.com")
                }
            };
            if(description.IsDeprecated)
            {
                info.Description += " This version of the api has been deprecated";
            }
            return info;
        }

    }
}

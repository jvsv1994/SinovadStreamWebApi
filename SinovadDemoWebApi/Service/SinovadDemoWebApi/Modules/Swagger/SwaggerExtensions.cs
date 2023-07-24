using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.Options;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;
using System.Reflection;

namespace SinovadDemoWebApi.Modules.Swagger
{
    public static class SwaggerExtensions
    {
        public static IServiceCollection AddSwagger(this IServiceCollection services)
        {

            services.AddTransient<IConfigureOptions<SwaggerGenOptions>, ConfigureSwaggerOptions>();

            services.AddSwaggerGen(sg =>
            {
                var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
                sg.IncludeXmlComments(xmlPath);

                var securityScheme = new OpenApiSecurityScheme
                {
                    Name = "Authorization",
                    Type = SecuritySchemeType.Http,
                    Scheme = "Bearer",
                    BearerFormat = "JWT",
                    In = ParameterLocation.Header,
                    Description = "Enter JWT Bearer token **_only_**",
                    Reference= new OpenApiReference
                    {
                        Id = JwtBearerDefaults.AuthenticationScheme,
                        Type = ReferenceType.SecurityScheme
                    }
                };
                sg.AddSecurityDefinition(securityScheme.Reference.Id,securityScheme);
                sg.AddSecurityRequirement(new OpenApiSecurityRequirement {
                    {      
                        securityScheme , new List<string>(){}
                    }
                });
               }
            );
            return services;
        }
    }
}

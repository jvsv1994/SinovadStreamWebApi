using HealthChecks.UI.Client;
using Microsoft.AspNetCore.Diagnostics.HealthChecks;
using Microsoft.AspNetCore.Mvc.ApiExplorer;
using SinovadDemo.Application.UseCases;
using SinovadDemo.Infrastructure;
using SinovadDemo.Persistence;
using SinovadDemoWebApi.Modules.Authentication;
using SinovadDemoWebApi.Modules.HealthCheck;
using SinovadDemoWebApi.Modules.Identity;
using SinovadDemoWebApi.Modules.Injection;
using SinovadDemoWebApi.Modules.Logger;
using SinovadDemoWebApi.Modules.RateLimiter;
using SinovadDemoWebApi.Modules.Swagger;
using SinovadDemoWebApi.Modules.Versioning;
using SinovadDemoWebApi.Modules.Watch;
using WatchDog;

var builder = WebApplication.CreateBuilder(args);

// Add services in web app
builder.Services.AddControllers().AddJsonOptions(options =>
{
    options.JsonSerializerOptions.PropertyNamingPolicy = null;
});
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddIdentity();
builder.Services.AddCors();

builder.Services.AddPersistenceServices(builder.Configuration);

builder.Services.AddInfrastructureServices();

builder.Services.AddApplicationServices();

builder.Services.AddInjection(builder.Configuration);
builder.Services.AddAuthentication(builder.Configuration);
builder.Services.AddVersioning();
builder.Services.AddSwagger();
builder.Services.AddHealthCheck(builder.Configuration);
builder.Services.AddWatchLog(builder.Configuration);
//builder.Services.AddRedisCache(builder.Configuration);
builder.Services.AddRateLimiting(builder.Configuration);

var app = builder.Build();

//configure the http request pipe line
if(app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}

app.UseSwagger();
app.UseSwaggerUI(c =>
{
    var provider = app.Services.GetRequiredService<IApiVersionDescriptionProvider>();
    foreach (var description in provider.ApiVersionDescriptions)
    {
        c.SwaggerEndpoint($"/swagger/{description.GroupName}/swagger.json", description.GroupName.ToUpperInvariant());
    }
});

app.UseWatchDogExceptionLogger();

app.Services.AddLogger(builder.Configuration, builder.Environment.EnvironmentName);
app.UseCors(options =>
{
    options.WithOrigins("*");
    options.AllowAnyMethod();
    options.AllowAnyHeader();
});

//app.UseHttpsRedirection();

app.UseRouting();
app.UseAuthentication();
app.UseAuthorization();
app.UseRateLimiter();
app.UseEndpoints(_ => { });
app.MapControllers();
app.MapHealthChecksUI();
app.MapHealthChecks("/health", new HealthCheckOptions
{
    Predicate = _ => true,
    ResponseWriter = UIResponseWriter.WriteHealthCheckUIResponse
});

app.UseWatchDog(conf=> {
    conf.WatchPageUsername = builder.Configuration["WatchDog:WatchPageUsername"];
    conf.WatchPagePassword = builder.Configuration["WatchDog:WatchPagePassword"];
 });

app.Run();

public partial class Program { };

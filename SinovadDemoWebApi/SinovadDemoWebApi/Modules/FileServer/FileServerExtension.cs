namespace SinovadDemoWebApi.Modules.FileServer
{
    public static class FileServerExtension
    {
        public static IApplicationBuilder AddFileServer(this IApplicationBuilder app )
        {
            try
            {
                var rootFolder = System.IO.Directory.GetCurrentDirectory();
                var fileServerOptionsWebApp = new FileServerOptions
                {
                    FileProvider = new Microsoft.Extensions.FileProviders.PhysicalFileProvider(rootFolder + "//wwwroot"),
                    RequestPath = new Microsoft.AspNetCore.Http.PathString(""),
                    EnableDirectoryBrowsing = true,
                    EnableDefaultFiles = false
                };
                fileServerOptionsWebApp.StaticFileOptions.ServeUnknownFileTypes = true;
                app.UseFileServer(fileServerOptionsWebApp);
            }
            catch ( Exception ex )
            {

            }
            return app;
        }

    }
}

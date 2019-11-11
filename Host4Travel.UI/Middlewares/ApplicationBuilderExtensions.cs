using System.IO;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.FileProviders;

namespace Host4Travel.UI.Middlewares
{
    public static class ApplicationBuilderExtensions
    {
        public static IApplicationBuilder UseNodeModules(this IApplicationBuilder app, string root)
        {
            var path = Path.Combine(root, "node_modules");
            var provider = new PhysicalFileProvider(path);
            var options=new StaticFileOptions();
            options.RequestPath = "/assets";
            options.FileProvider = provider;
            app.UseStaticFiles(options);
            return app;
        }
    }
}
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.FileProviders;
using System.IO;

namespace PMS.Dependencies
{
    public static class StaticFilesDependencies
    {
        public static IApplicationBuilder UseStaticFilesDependencies(this IApplicationBuilder app)
        {
            app.UseStaticFiles(new StaticFileOptions
            {
                FileProvider = new PhysicalFileProvider(Path.Combine(Directory.GetCurrentDirectory(), @"Resources")),
                RequestPath = new Microsoft.AspNetCore.Http.PathString("/Resources")
            });
            app.UseStaticFiles(new StaticFileOptions
            {
                FileProvider = new PhysicalFileProvider(Path.Combine(Directory.GetCurrentDirectory(), @"Resources/TreatmentImages")),
                RequestPath = new Microsoft.AspNetCore.Http.PathString("/treatment-images")
            });
            app.UseStaticFiles(new StaticFileOptions
            {
                FileProvider = new PhysicalFileProvider(Path.Combine(Directory.GetCurrentDirectory(), @"Resources/PatientImages")),
                RequestPath = new Microsoft.AspNetCore.Http.PathString("/patient-images")
            });
            return app;
        }
    }
}

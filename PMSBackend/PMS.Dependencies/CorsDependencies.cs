using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

namespace PMS.Dependencies
{
    public static class CorsDependencies
    {
        public static IServiceCollection AddCorsDependencies(this IServiceCollection services)
        {
            services.AddCors(options =>
            {
                options.AddPolicy("PMSCors", pmsCorsPolicy => pmsCorsPolicy.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());
            });
            return services;
        }

        public static IApplicationBuilder UseCorsDependency(this IApplicationBuilder app)
        {
            app.UseCors("PMSCors");
            return app;
        }
    }
}

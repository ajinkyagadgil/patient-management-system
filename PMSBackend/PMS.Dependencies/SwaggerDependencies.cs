using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;

namespace PMS.Dependencies
{
    public static class SwaggerServiceExtenstion
    {
        public static IServiceCollection AddSwaggerDocumentation(this IServiceCollection services)
        {
            //Here as I have used custom Swagger doc the name of the swaggger doc ie v1 must be same in the Swagger endpoint path as v1
            services.AddSwaggerGen(options =>
            {
                options.SwaggerDoc("v1", new OpenApiInfo { Title = "PMS API", Version = "1.0", Contact = new OpenApiContact { Name = "Ajinkya Gadgil", Email = "ajinkyargadgil@gmail.com" }, Description = "API for Patient Management System", License = new OpenApiLicense { Name = "PMS" } });
                options.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                {
                    Description = "JWT Authorization using Bearer scheme",
                    Name = "Authorization",
                    In = ParameterLocation.Header,
                    Type = SecuritySchemeType.ApiKey
                });
            });

            return services;
        }

        public static IApplicationBuilder UseSwaggerDocumentation(this IApplicationBuilder app)
        {
            app.UseSwagger();

            app.UseSwaggerUI(options =>
            {
                options.SwaggerEndpoint("/swagger/v1/swagger.json", "PMS API V1");
                options.DocExpansion(Swashbuckle.AspNetCore.SwaggerUI.DocExpansion.None);
            });

            return app;
        }
    }
}

using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.FileProviders;
using Microsoft.Extensions.Hosting;
using PMS.Dependencies;
using PMSBackend.Handler.Common;
using PMSBackend.Handler.Patient;
using PMSBackend.Handler.Treatment;
using System.IO;

namespace PMSBackend
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();

            var connectionString = Configuration.GetSection("ConnectionStrings").GetSection("DatabaseConnection").Value;
            services.AddDatabaseContextDependency(connectionString); //custom method in dependency project
            services.AddSwaggerDocumentation(); //custom method in dependency project
            services.AddScoped<IPatientHandler, PatientHandler>();
            services.AddScoped<ICommonHandler, CommonHandler>();
            services.AddScoped<ITreatmentHandler, TreatmentHandler>();
            services.RegisterServices(); //custom method in dependency project
            services.AddCorsDependencies(); //custom method in dependency project
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseStaticFilesDependencies(); //cusom method for static files dependencies

            app.UseSwaggerDocumentation();

            app.UseHttpsRedirection();

            app.UseCorsDependency(); //custom method in dependency project

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}

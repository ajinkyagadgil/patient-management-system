using Microsoft.Extensions.DependencyInjection;
using Patient.Core.Implementation;
using Patient.Core.IQueries;
using Patient.Core.Services;
using Patient.Data.Repository;
using Patient.Domain.IRepository;
using Patient.Domain.Queries;

namespace PMS.Dependencies
{
    public static class PatientServiceDependencies
    {
        public static IServiceCollection RegisterServices(this IServiceCollection services)
        {
            services.AddScoped<IPatientService, PatientService>();
            services.AddScoped<IPatientQuery, PatientQuery>();
            services.AddScoped<IPatientRepository, PatientRepository>();
            return services;
        }
    }
}

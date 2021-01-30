using Microsoft.Extensions.DependencyInjection;
using Patient.Core.Implementation;
using Patient.Core.IQueries;
using Patient.Core.Services;
using Patient.Data.Repository;
using Patient.Domain.IRepository;
using Patient.Domain.Queries;

namespace PMS.Dependencies
{
    public static class PmsServiceDependencies
    {
        public static IServiceCollection RegisterServices(this IServiceCollection services)
        {
            services.AddScoped<IPatientService, PatientService>();
            services.AddScoped<IPatientQuery, PatientQuery>();
            services.AddScoped<ITreatmentService, TreatmentService>();
            services.AddScoped<ITreatmentQuery, TreatmentQuery>();
            services.AddScoped<IPatientRepository, PatientRepository>();
            services.AddScoped<ITreatmentRepository, TreatmentRepository>();
            return services;
        }
    }
}

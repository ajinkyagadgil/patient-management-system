using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Patient.Data.Context;

namespace PMS.Dependencies
{
    public static class DatabaseDependencies
    {
        public static IServiceCollection AddDatabaseContextDependency(this IServiceCollection services, string connectionString)
        {
            services.AddDbContext<PatientDBContext>(options => options.UseSqlServer(connectionString));
            return services;
        }
    }
}

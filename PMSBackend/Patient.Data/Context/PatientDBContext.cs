using Microsoft.EntityFrameworkCore;
using Patient.Domain.Models;

namespace Patient.Data.Context
{
    public class PatientDBContext: DbContext
    {
        public PatientDBContext(DbContextOptions<PatientDBContext> options) : base(options)
        {
        }

        public virtual DbSet<PatientInformation> PatientsInformation { get; set; }
    }
}

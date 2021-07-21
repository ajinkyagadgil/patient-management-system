using Microsoft.EntityFrameworkCore;
using Patient.Domain.Models;

namespace Patient.Data.Context
{
    public class PMSDBContext: DbContext
    {
        public PMSDBContext(DbContextOptions<PMSDBContext> options) : base(options)
        {
        }

        public virtual DbSet<PatientInformation> PatientsInformation { get; set; }
        public virtual DbSet<PatientPhoto> PatientPhoto { get; set; }
        public virtual DbSet<TreatmentInformation> TreatmentInformation { get; set; }
        public virtual DbSet<TreatmentFiles> TreatmentFiles { get; set; }
        public virtual DbSet<Roles> Roles { get; set; }
        public virtual DbSet<RecordInformation> RecordInformation { get; set; }
        public virtual DbSet<Users> Users { get; set; }
    }
}

using Microsoft.EntityFrameworkCore;
using Patient.Data.Context;
using Patient.Domain.IRepository;
using Patient.Domain.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Patient.Data.Repository
{
    public class PatientRepository : IPatientRepository
    {
        private readonly PatientDBContext _patientContext;
        public PatientRepository(PatientDBContext patientContext)
        {
            _patientContext = patientContext;
    }

        public async Task<List<PatientInformation>> GetPatientsInformation()
        {
            return  await _patientContext.PatientsInformation.ToListAsync();
        }
    }
}

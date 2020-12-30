using Patient.Core.Entities;
using Patient.Core.IQueries;
using Patient.Domain.IRepository;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Patient.Domain.Queries
{
    public class PatientQuery : IPatientQuery
    {
        private readonly IPatientRepository _patientRepository;

        public PatientQuery(IPatientRepository patientRepository)
        {
            _patientRepository = patientRepository;
        }

        public async Task<List<PatientInformation>> GetPatientsInformation()
        {
            throw new NotImplementedException();
        }
    }
}

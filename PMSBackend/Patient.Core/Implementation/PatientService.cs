using Patient.Core.Entities;
using Patient.Core.IQueries;
using Patient.Core.Services;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Patient.Core.Implementation
{
    public class PatientService : IPatientService
    {
        private readonly IPatientQuery _patientQuery;

        public PatientService(IPatientQuery patientQuery)
        {
            _patientQuery = patientQuery;
        }

        public async Task<List<PatientInformation>> GetPatientsInformation()
        {
            return await _patientQuery.GetPatientsInformation();
        }
    }
}

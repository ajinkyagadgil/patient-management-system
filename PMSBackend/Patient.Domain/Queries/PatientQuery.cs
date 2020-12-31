using Patient.Core.Entities;
using Patient.Core.IQueries;
using Patient.Domain.IRepository;
using Patient.Domain.Models;
using System.Collections.Generic;
using System.Linq;
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

        public async Task<List<PatientInformationEntity>> GetPatientsInformation()
        {
            return (await _patientRepository.GetPatientsInformation()).Select(x => x.ToModelEntity()).ToList();
        }
    }
}

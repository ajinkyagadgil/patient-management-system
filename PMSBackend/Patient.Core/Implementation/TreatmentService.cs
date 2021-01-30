using Patient.Core.Entities.Treatment;
using Patient.Core.IQueries;
using Patient.Core.Services;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Patient.Core.Implementation
{
    public class TreatmentService : ITreatmentService
    {
        private readonly ITreatmentQuery _treatmentQuery;
        public TreatmentService(ITreatmentQuery treatmentQuery)
        {
            _treatmentQuery = treatmentQuery;
        }

        public async Task<List<GetTreatmentInformationEntity>> GetPatientTreatments(Guid patientId)
        {
            return (await _treatmentQuery.GetPatientTreatments(patientId));
        }
    }
}

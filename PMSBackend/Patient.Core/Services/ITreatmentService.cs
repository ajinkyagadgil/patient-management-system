using Patient.Core.Entities.Treatment;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Patient.Core.Services
{
    public interface ITreatmentService
    {
        Task<List<GetTreatmentInformationEntity>> GetPatientTreatments(Guid patientId);
    }
}

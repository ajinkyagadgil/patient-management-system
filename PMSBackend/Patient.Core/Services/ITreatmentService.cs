using Patient.Core.Entities.Patient;
using Patient.Core.Entities.Treatment;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Patient.Core.Services
{
    public interface ITreatmentService
    {
        Task<List<GetTreatmentInformationEntity>> GetPatientTreatments(Guid patientId);
        Task SavePatientTreatment(PostTreatmentInformationEntity postTreatmentInformationEntity);
        Task DeleteTreatmentInformation(Guid treatmentId);
        Task DeleteTreatmentImage(Guid treatmentImageId);
    }
}

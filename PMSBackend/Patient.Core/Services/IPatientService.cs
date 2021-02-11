using Patient.Core.Entities.Patient;
using Patient.Core.Entities.Treatment;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Patient.Core.Services
{
    public interface IPatientService
    {
        Task<List<GetPatientInformationEntity>> GetPatientsInformation();
        Task<GetPatientInformationEntity> GetPatientInformation(Guid patientId);
        Task SavePatientAndTreatmentInformation(PostPatientInformationEntity postPatientInformationEntity, PostTreatmentInformationEntity postTreatmentInformationEntity);
        Task SavePatientInformation(PostPatientInformationEntity postPatientInformationEntity);
        Task DeletePatientAndTreatmentInformation(Guid patientId);
    }
}

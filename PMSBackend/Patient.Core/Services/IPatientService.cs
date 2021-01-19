using Patient.Core.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Patient.Core.Services
{
    public interface IPatientService
    {
        Task<List<PatientInformationEntity>> GetPatientsInformation();
        Task SavePatientAndTreatmentInformation(PostPatientInformationEntity postPatientInformationEntity, PostTreatmentInformationEntity postTreatmentInformationEntity);
    }
}

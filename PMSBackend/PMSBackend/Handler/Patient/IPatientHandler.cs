using PMSBackend.Handler.Patient.ViewModels;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PMSBackend.Handler.Patient
{
    public interface IPatientHandler
    {
        Task<List<GetPatientInfomationViewModel>> GetPatientsInformation();
        Task<GetPatientInfomationViewModel> GetPatientInformation(Guid patientId);
        Task SavePatientAndTreatmentInformation(SavePatientAndTreatmentInformationViewModel savePatientAndTreatmentInformationViewModel);
        Task SavePatientInformation(PostPatientInformationViewModel postPatientInformationViewModel);
    }
}

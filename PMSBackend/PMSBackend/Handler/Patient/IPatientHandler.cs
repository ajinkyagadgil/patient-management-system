using PMSBackend.Handler.Patient.ViewModels;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PMSBackend.Handler.Patient
{
    public interface IPatientHandler
    {
        Task<List<PatientInfomationViewModel>> GetPatientsInformation();
        Task SavePatientAndTreatmentInformation(SavePatientAndTreatmentInformationViewModel savePatientAndTreatmentInformationViewModel);
    }
}

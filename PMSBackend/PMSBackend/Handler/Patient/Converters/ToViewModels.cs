using Patient.Core.Entities;
using PMSBackend.Handler.Patient.ViewModels;

namespace PMSBackend.Handler.Patient.Converters
{
    public static class ToViewModels
    {
        public static PatientInfomationViewModel ToViewModel(this PatientInformationEntity patientInformation)
        => patientInformation == null ? null : new PatientInfomationViewModel
        {
            id = patientInformation.Id,
            name = patientInformation.Name,
            age = patientInformation.Age,
            phone = patientInformation.Phone,
            gender = (patientInformation.Gender).ToString(),
            history = patientInformation.History,
            caseNo = patientInformation.CaseNo,
            photoPath = patientInformation.PhotoPath
        };
    }
}

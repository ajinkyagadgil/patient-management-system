using Patient.Core.Common.Enums;
using Patient.Core.Entities;
using PMSBackend.Handler.Common.ViewModels;
using PMSBackend.Handler.Patient.ViewModels;

namespace PMSBackend.Handler.Patient.Converters
{
    public static class ToViewModels
    {
        public static PatientInfomationViewModel ToViewModel(this PatientInformationEntity patientInformation)
        => patientInformation == null ? null : new PatientInfomationViewModel
        {
            id = patientInformation.Id,
            firstName = patientInformation.FirstName,
            lastName = patientInformation.LastName,
            email = patientInformation.Email,
            age = patientInformation.Age,
            phone = patientInformation.Phone,
            gender = (patientInformation.Gender).ToViewModel(),
            history = patientInformation.History,
            caseNo = patientInformation.CaseNo,
            photoPath = patientInformation.PhotoPath
        };

        public static GenderViewModel ToViewModel(this Gender gender)
        => gender < 0 ? null : new GenderViewModel
        {
            id = (int)gender,
            name = gender.ToString()
        };
    }
}

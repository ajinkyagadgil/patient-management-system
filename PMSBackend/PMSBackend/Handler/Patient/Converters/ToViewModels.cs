using Patient.Core.Entities;
using Patient.Core.Entities.Patient;
using PMSBackend.Handler.Common.Converters;
using PMSBackend.Handler.Patient.ViewModels;

namespace PMSBackend.Handler.Patient.Converters
{
    public static class ToViewModels
    {
        public static PatientInformationBaseViewModel ToViewModel(this PatientInformationBaseEntity patientInformation)
        => patientInformation == null ? null : new GetPatientInfomationViewModel
        {
            id = patientInformation.Id,
            firstName = patientInformation.FirstName,
            lastName = patientInformation.LastName,
            email = patientInformation.Email,
            age = patientInformation.Age,
            phone = patientInformation.Phone,
            gender = patientInformation.Gender.ToViewModel(),
            history = patientInformation.History,
            caseNo = patientInformation.CaseNo
        };

        public static GetPatientInfomationViewModel ToViewModel(this GetPatientInformationEntity getPatientInformationEntity)
        => getPatientInformationEntity == null ? null : new GetPatientInfomationViewModel
        {
            id = getPatientInformationEntity.Id,
            firstName = getPatientInformationEntity.FirstName,
            lastName = getPatientInformationEntity.LastName,
            email = getPatientInformationEntity.Email,
            age = getPatientInformationEntity.Age,
            phone = getPatientInformationEntity.Phone,
            gender = getPatientInformationEntity.Gender.ToViewModel(),
            history = getPatientInformationEntity.History,
            caseNo = getPatientInformationEntity.CaseNo,
            patientPhotoInformation = getPatientInformationEntity.PatientPhotoInformation.ToViewModel()
        };
    }
}

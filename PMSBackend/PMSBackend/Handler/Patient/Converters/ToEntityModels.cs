using Patient.Core.Entities.Patient;
using PMSBackend.Handler.Patient.ViewModels;

namespace PMSBackend.Handler.Patient.Converters
{
    public static class ToEntityModels
    {
        public static PatientInformationBaseEntity ToEntityModel(this PatientInformationBaseViewModel patientInformationBaseViewModel)
        => patientInformationBaseViewModel == null ? null : new PatientInformationBaseEntity
        {
            Id = patientInformationBaseViewModel.id,
            FirstName = patientInformationBaseViewModel.firstName,
            LastName = patientInformationBaseViewModel.lastName,
            Email = patientInformationBaseViewModel.email,
            Age = patientInformationBaseViewModel.age,
            Phone = patientInformationBaseViewModel.phone,
            Gender = patientInformationBaseViewModel.gender,
            History = patientInformationBaseViewModel.history,
            CaseNo = patientInformationBaseViewModel.caseNo
        };

        public static PostPatientInformationEntity ToEntityModel(this PostPatientInformationViewModel postPatientInformationViewModel)
        => postPatientInformationViewModel == null ? null : new PostPatientInformationEntity
        {
            Id = postPatientInformationViewModel.id,
            FirstName = postPatientInformationViewModel.firstName,
            LastName = postPatientInformationViewModel.lastName,
            Email = postPatientInformationViewModel.email,
            Age = postPatientInformationViewModel.age,
            Phone = postPatientInformationViewModel.phone,
            Gender = postPatientInformationViewModel.gender,
            History = postPatientInformationViewModel.history,
            CaseNo = postPatientInformationViewModel.caseNo,
            PatientPhoto = postPatientInformationViewModel.patientPhoto
        };
    }
}

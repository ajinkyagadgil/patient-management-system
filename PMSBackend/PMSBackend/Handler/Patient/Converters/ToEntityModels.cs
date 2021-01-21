using Microsoft.AspNetCore.Http;
using Patient.Core.Entities;
using PMSBackend.Handler.Patient.ViewModels;
using System.Collections.Generic;

namespace PMSBackend.Handler.Patient.Converters
{
    public static class ToEntityModels
    {
        public static PostPatientInformationEntity ToEntityModel(this PostPatientInformationViewModel postPatientInformationViewModel, IFormFile patientPhoto)
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
            PatientPhoto = patientPhoto
        };

        public static PostTreatmentInformationEntity ToEntityModel(this PostTreatmentInformationViewModel postTreatmentInformationViewModel, List<IFormFile> treatmentFiles)
        => postTreatmentInformationViewModel == null ? null : new PostTreatmentInformationEntity
        {
            Id = postTreatmentInformationViewModel.id,
            Title = postTreatmentInformationViewModel.title,
            Summary = postTreatmentInformationViewModel.summary,
            TreatmentDate = postTreatmentInformationViewModel.treatmentDate,
            TreatmentFiles = treatmentFiles
        };
    }
}

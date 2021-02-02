using Microsoft.AspNetCore.Http;
using Patient.Core.Entities.Treatment;
using PMSBackend.Handler.Patient.ViewModels;
using System.Collections.Generic;

namespace PMSBackend.Handler.Treatment.Converters
{
    public static class ToEntityModels
    {
        public static PostTreatmentInformationEntity ToEntityModel(this PostTreatmentInformationViewModel postTreatmentInformationViewModel)
        => postTreatmentInformationViewModel == null ? null : new PostTreatmentInformationEntity
        {
            Id = postTreatmentInformationViewModel.id,
            PatientId = postTreatmentInformationViewModel.patientId,
            Title = postTreatmentInformationViewModel.title,
            Summary = postTreatmentInformationViewModel.summary,
            TreatmentDate = postTreatmentInformationViewModel.treatmentDate,
            TreatmentFiles = postTreatmentInformationViewModel.treatmentFiles
        };
    }
}

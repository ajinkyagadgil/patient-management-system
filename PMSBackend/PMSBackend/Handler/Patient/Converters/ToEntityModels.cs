using Microsoft.AspNetCore.Http;
using Patient.Core.Common.Enums;
using Patient.Core.Entities;
using Patient.Core.Entities.Patient;
using Patient.Core.Entities.Treatment;
using PMSBackend.Handler.Patient.ViewModels;
using System.Collections.Generic;

namespace PMSBackend.Handler.Patient.Converters
{
    public static class ToEntityModels
    {
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

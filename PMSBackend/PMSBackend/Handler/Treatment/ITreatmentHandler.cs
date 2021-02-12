using PMSBackend.Handler.Patient.ViewModels;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PMSBackend.Handler.Treatment
{
    public interface ITreatmentHandler
    {
        Task<List<GetTreatmentInformationViewModel>> GetPatientTreatments(Guid patientId);
        Task SavePatientTreatment(PostTreatmentInformationViewModel postTreatmentInformationViewModel);
        Task DeleteTreatmentInformation(Guid treatmentId);
    }
}

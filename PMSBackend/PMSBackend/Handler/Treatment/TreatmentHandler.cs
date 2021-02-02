using Patient.Core.Services;
using PMSBackend.Handler.Patient.ViewModels;
using PMSBackend.Handler.Treatment.Converters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PMSBackend.Handler.Treatment
{
    public class TreatmentHandler : ITreatmentHandler
    {
        private readonly ITreatmentService _treatmentService;
        public TreatmentHandler(ITreatmentService treatmentService)
        {
            _treatmentService = treatmentService;
        }

        public async Task<List<GetTreatmentInformationViewModel>> GetPatientTreatments(Guid patientId)
        {
            return (await _treatmentService.GetPatientTreatments(patientId)).Select(x => x.ToViewModel()).ToList();
        }

        public async Task SavePatientTreatment(PostTreatmentInformationViewModel postTreatmentInformationViewModel)
        {
            await _treatmentService.SavePatientTreatment(postTreatmentInformationViewModel.ToEntityModel());
        }
    }
}

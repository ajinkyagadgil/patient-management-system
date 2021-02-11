using Newtonsoft.Json;
using Patient.Core.Services;
using PMSBackend.Handler.Patient.Converters;
using PMSBackend.Handler.Patient.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PMSBackend.Handler.Patient
{
    public class PatientHandler : IPatientHandler
    {
        private readonly IPatientService _patientService;
        public PatientHandler(IPatientService patientService)
        {
            _patientService = patientService;
        }

        public async Task<List<GetPatientInfomationViewModel>> GetPatientsInformation()
        {
            return (await _patientService.GetPatientsInformation()).Select(x => x.ToViewModel()).ToList();
        }

        public async Task<GetPatientInfomationViewModel> GetPatientInformation(Guid patientId)
        {
            return (await _patientService.GetPatientInformation(patientId)).ToViewModel();
        }

        public async Task SavePatientAndTreatmentInformation(SavePatientAndTreatmentInformationViewModel savePatientAndTreatmentInformationViewModel)
        {
            try
            {
                var patientInformation = JsonConvert.DeserializeObject<PostPatientInformationViewModel>(savePatientAndTreatmentInformationViewModel.patientInformation);
                var treatmentInformation = JsonConvert.DeserializeObject<PostTreatmentInformationViewModel>(savePatientAndTreatmentInformationViewModel.treatmentInformation);
                //await _patientService.SavePatientAndTreatmentInformation(patientInformation.ToEntityModel(savePatientAndTreatmentInformationViewModel.patientPhoto), treatmentInformation.ToEntityModel(savePatientAndTreatmentInformationViewModel.treatmentPhoto));
            }
            catch(Exception ex)
            {

            }
        }

        public async Task SavePatientInformation(PostPatientInformationViewModel postPatientInformationViewModel)
        {
            await _patientService.SavePatientInformation(postPatientInformationViewModel.ToEntityModel());
        }

        public async Task DeletePatientAndTreatmentInformation(Guid patientId)
        {
            await _patientService.DeletePatientAndTreatmentInformation(patientId);
        }
    }
}

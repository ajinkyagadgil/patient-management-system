using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using PMSBackend.Handler.Patient;
using PMSBackend.Handler.Patient.ViewModels;
using System;
using System.Threading.Tasks;

namespace PMSBackend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PatientController : ControllerBase
    {
        private readonly IPatientHandler _patientHandler;
        public PatientController(IPatientHandler patientHandler)
        {
            _patientHandler = patientHandler;
        }

        [Route("get/all")]
        [HttpGet]
        public async Task<IActionResult> GetPatientsInformation()
        {
            return Ok(await _patientHandler.GetPatientsInformation());
        }

        [Route("get/{patientId}")]
        [HttpGet]
        public async Task<IActionResult> GetPatientInformation([FromRoute]Guid patientId)
        {
            return Ok(await _patientHandler.GetPatientInformation(patientId));
        }

        [Route("save")]
        [HttpPost]
        public async Task<IActionResult> SavePatientInformation([FromForm]PatientInformationFormDataViewModel patientInformationFormDataViewModel)
        {
            try
            {
                var patientInformation = JsonConvert.DeserializeObject<PostPatientInformationViewModel>(patientInformationFormDataViewModel.patientInformation);
                patientInformation.patientPhoto = patientInformationFormDataViewModel.patientPhoto;
                await _patientHandler.SavePatientInformation(patientInformation);
                return Ok();
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        [Route("savePatientAndTreatment")]
        [HttpPost]
        public async Task<IActionResult> SavePatientAndTreatmentInformation([FromForm]SavePatientAndTreatmentInformationViewModel savePatientAndTreatmentInformationViewModel)
        {
            await _patientHandler.SavePatientAndTreatmentInformation(savePatientAndTreatmentInformationViewModel);
            return Ok();
        }
    }
}
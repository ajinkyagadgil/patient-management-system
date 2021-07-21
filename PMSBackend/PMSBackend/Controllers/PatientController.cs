using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
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
        private readonly ILogger<PatientController> _logger;
        public PatientController(IPatientHandler patientHandler, ILogger<PatientController> logger)
        {
            _patientHandler = patientHandler;
            _logger = logger;
        }

        [Route("get/all")]
        [HttpGet]
        public async Task<IActionResult> GetPatientsInformation()
        {
            try
            {
                return Ok(await _patientHandler.GetPatientsInformation());
            }
            catch(Exception ex)
            {
                _logger.LogError(ex, ex.Message, null);
                return BadRequest("Some error occured while fetching the patients.");
            }
        }

        [Route("get/{patientId}")]
        [HttpGet]
        public async Task<IActionResult> GetPatientInformation([FromRoute]Guid patientId)
        {
            try
            {
                return Ok(await _patientHandler.GetPatientInformation(patientId));
            }
            catch(Exception ex)
            {
                _logger.LogError(ex, ex.Message, null);
                return BadRequest("Some error occured while fetching the patient details.");
            }
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
                _logger.LogError(ex, ex.Message, null);
                return BadRequest("Some error occured while saving the patient details.");
            }
        }

        [Route("delete/{patientId}")]
        [HttpDelete]
        public async Task<IActionResult> DeletePatientAndTreatmentInformation([FromRoute]Guid patientId)
        {
            try
            {
                await _patientHandler.DeletePatientAndTreatmentInformation(patientId);
                return Ok();
            }
            catch(Exception ex)
            {
                _logger.LogError(ex, ex.Message, null);
                return BadRequest("Some error occured while deleting patient details.");
            }
        }

        [Route("savePatientAndTreatment")]
        [HttpPost]
        public async Task<IActionResult> SavePatientAndTreatmentInformation([FromForm]SavePatientAndTreatmentInformationViewModel savePatientAndTreatmentInformationViewModel)
        {
            try
            {
                await _patientHandler.SavePatientAndTreatmentInformation(savePatientAndTreatmentInformationViewModel);
                return Ok();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message, null);
                return BadRequest("Some error occured while saving patient information");
            }
        }

        [Route("photo/delete/{patientPhotoId}")]
        [HttpDelete]
        public async Task<IActionResult> DeletePatientPhoto([FromRoute] Guid patientPhotoId)
        {
            try
            {
                await _patientHandler.DeletePatientPhoto(patientPhotoId);
                return Ok();
            }
            catch(Exception ex)
            {
                _logger.LogError(ex, ex.Message, null);
                return BadRequest("Some error occured while deleting patient photo");
            }
        }
    }
}
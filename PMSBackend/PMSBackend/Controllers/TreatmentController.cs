using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using PMSBackend.Handler.Patient.ViewModels;
using PMSBackend.Handler.Treatment;
using PMSBackend.Handler.Treatment.ViewModels;
using System;
using System.Threading.Tasks;

namespace PMSBackend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TreatmentController : ControllerBase
    {
        private readonly ITreatmentHandler _treatmentHandler;
        private readonly ILogger<TreatmentController> _logger;

        public TreatmentController(ITreatmentHandler treatmentHandler, ILogger<TreatmentController> logger)
        {
            _treatmentHandler = treatmentHandler;
            _logger = logger;
        }

        [Route("all/{patientId}")]
        [HttpGet]
        public async Task<IActionResult> GetPatientTreatments([FromRoute]Guid patientId)
        {
            try
            {
                return Ok(await _treatmentHandler.GetPatientTreatments(patientId));
            }
            catch(Exception ex)
            {
                _logger.LogError(ex, ex.Message, null);
                return BadRequest("Some error occured while fetching the patient treatments.");
            }
        }

        [Route("save")]
        [HttpPost]
        public async Task<IActionResult> SavePatientTreatment([FromForm]TreatmentInformationFormDataViewModel treatmentInformationFormDataViewModel )
        {
            try
            {
                var treatmentInformation = JsonConvert.DeserializeObject<PostTreatmentInformationViewModel>(treatmentInformationFormDataViewModel.treatmentInformation);
                treatmentInformation.treatmentFiles = treatmentInformationFormDataViewModel.treatmentFiles;
                await _treatmentHandler.SavePatientTreatment(treatmentInformation);
                return Ok();
            }
            catch(Exception ex)
            {
                _logger.LogError(ex, ex.Message, null);
                return BadRequest("Some error occured while fetching the saving patient treatment.");
            }
        }

        [Route("delete/{treatmentId}")]
        [HttpDelete]
        public async Task<IActionResult> DeleteTreatmentInformation([FromRoute]Guid treatmentId)
        {
            try
            {
                await _treatmentHandler.DeleteTreatmentInformation(treatmentId);
                return Ok();
            }
            catch(Exception ex)
            {
                _logger.LogError(ex, ex.Message, null);
                return BadRequest("Some error occured while fetching the deleting patient treatment.");
            }
        }

        [HttpDelete("image/delete/{treatmentImageId}")]
        public async Task<IActionResult> DeleteTreatmentImage([FromRoute]Guid treatmentImageId)
        {
            try
            {
                await _treatmentHandler.DeleteTreatmentImage(treatmentImageId);
                return Ok();
            }
            catch(Exception ex)
            {
                _logger.LogError(ex, ex.Message, null);
                return BadRequest("Some error occured while deleting treatment image.");
            }
        }
    }
}
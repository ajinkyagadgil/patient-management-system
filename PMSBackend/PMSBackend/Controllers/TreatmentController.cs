using Microsoft.AspNetCore.Mvc;
using PMSBackend.Handler.Treatment;
using System;
using System.Threading.Tasks;

namespace PMSBackend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TreatmentController : ControllerBase
    {
        private readonly ITreatmentHandler _treatmentHandler;
        public TreatmentController(ITreatmentHandler treatmentHandler)
        {
            _treatmentHandler = treatmentHandler;
        }

        [Route("all/{patientId}")]
        [HttpGet]
        public async Task<IActionResult> GetPatientTreatments([FromRoute]Guid patientId)
        {
            return Ok(await _treatmentHandler.GetPatientTreatments(patientId));
        } 
    }
}
using Microsoft.AspNetCore.Mvc;
using PMSBackend.Handler.Patient;

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
        public IActionResult GetPatientsInformation()
        {
            return Ok(_patientHandler.GetPatientsInformation());
        }
    }
}
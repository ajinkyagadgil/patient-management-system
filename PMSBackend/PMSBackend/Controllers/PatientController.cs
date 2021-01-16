using Microsoft.AspNetCore.Mvc;
using PMSBackend.Handler.Patient;
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

        [Route("save")]
        [HttpPost]
        public async Task<IActionResult> SavePatientInformation([FromForm]  string a)
        {
            return Ok();
        }
    }
}
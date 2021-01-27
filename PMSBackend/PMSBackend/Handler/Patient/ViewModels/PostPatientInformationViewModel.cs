using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;

namespace PMSBackend.Handler.Patient.ViewModels
{
    public class PostPatientInformationViewModel : PatientInformationBaseViewModel
    {
        [JsonIgnore]
        public IFormFile patientPhoto { get; set; }
    }
}

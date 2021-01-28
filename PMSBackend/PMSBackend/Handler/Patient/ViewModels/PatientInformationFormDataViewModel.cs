using Microsoft.AspNetCore.Http;

namespace PMSBackend.Handler.Patient.ViewModels
{
    public class PatientInformationFormDataViewModel
    {
        public string patientInformation { get; set; }
        public IFormFile patientPhoto { get; set; }
    }
}

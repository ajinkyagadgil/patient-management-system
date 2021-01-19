using Microsoft.AspNetCore.Http;
using System.Collections.Generic;

namespace PMSBackend.Handler.Patient.ViewModels
{
    public class SavePatientAndTreatmentInformationViewModel
    {
        public IFormFile patientPhoto { get; set; }
        public List<IFormFile> treatmentPhoto { get; set; }
        public string patientInformation { get; set; }
        public string treatmentInformation { get; set; }
    }
}

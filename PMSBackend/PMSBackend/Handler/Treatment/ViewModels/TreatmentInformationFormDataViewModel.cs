using Microsoft.AspNetCore.Http;
using System.Collections.Generic;

namespace PMSBackend.Handler.Treatment.ViewModels
{
    public class TreatmentInformationFormDataViewModel
    {
        public string treatmentInformation { get; set; }
        public List<IFormFile> treatmentFiles { get; set; }
    }
}

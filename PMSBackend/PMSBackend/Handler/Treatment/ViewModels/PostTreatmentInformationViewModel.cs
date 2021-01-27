using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace PMSBackend.Handler.Patient.ViewModels
{
    public class PostTreatmentInformationViewModel: TreatmentInformationBaseViewModel
    {
        [JsonIgnore]
        public List<IFormFile> treatmentFiles { get; set; }
    }
}

using System;
using System.Collections.Generic;

namespace PMSBackend.Handler.Patient.ViewModels
{
    public class PostTreatmentInformationViewModel
    {
        public string title { get; set; }
        public string summary { get; set; }
        public DateTime treatmentDate { get; set; }
    }
}

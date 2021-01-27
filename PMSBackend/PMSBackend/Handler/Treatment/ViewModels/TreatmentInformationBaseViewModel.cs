using System;

namespace PMSBackend.Handler.Patient.ViewModels
{
    public class TreatmentInformationBaseViewModel
    {
        public Guid id { get; set; }
        public string title { get; set; }
        public string summary { get; set; }
        public DateTime treatmentDate { get; set; }
    }
}

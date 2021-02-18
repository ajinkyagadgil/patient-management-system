using PMSBackend.Handler.Patient.ViewModels;
using System;

namespace PMSBackend.Handler.Record.ViewModels
{
    public class RecordInformationViewModel
    {
        public Guid id { get; set; }
        public Guid patientId { get; set; }
        public string treatment { get; set; }
        public int amount { get; set; }
        public DateTime recordDate { get; set; }
        public PatientInformationBaseViewModel PatientInformation { get; set; }
    }
}

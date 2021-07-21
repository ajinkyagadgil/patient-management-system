using Patient.Core.Entities.Patient;
using System;

namespace Patient.Core.Entities.Record
{
    public class RecordInformationEntity
    {
        public Guid Id { get; set; }
        public Guid PatientId { get; set; }
        public string Treatment { get; set; }
        public int Amount { get; set; }
        public DateTime RecordDate { get; set; }
        public PatientInformationBaseEntity PatientInformation { get; set; }
    }
}

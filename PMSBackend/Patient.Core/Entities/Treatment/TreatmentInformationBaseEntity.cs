using System;

namespace Patient.Core.Entities.Treatment
{
    public class TreatmentInformationBaseEntity
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Summary { get; set; }
        public DateTime TreatmentDate { get; set; }
    }
}

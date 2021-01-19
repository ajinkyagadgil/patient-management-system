using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Patient.Domain.Models
{
    [Table("TreatmentInformation", Schema = "Treatment")]
    public class TreatmentInformation
    {
        [Key]
        public Guid Id { get; set; }
        [ForeignKey("PatientInformation")]
        public Guid PatientId { get; set; }
        public PatientInformation PatientInformation { get; set; }
        public string Title { get; set; }
        public string Summary { get; set; }
        public DateTime Date { get; set; }
    }
}

using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Patient.Domain.Models
{
    [Table("TreatmentFiles", Schema = "Treatment")]
    public class TreatmentFiles
    {
        [Key]
        public Guid Id { get; set; }

        [ForeignKey("TreatmentInformation")]
        public Guid TreatmentId { get; set; }
        public virtual TreatmentInformation TreatmentInformation { get; set; }
        public string Path { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
        public long Size { get; set; }
        public DateTime CreationDate { get; set; }
    }
}

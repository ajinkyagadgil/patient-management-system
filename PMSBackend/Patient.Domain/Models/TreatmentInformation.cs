using Patient.Core.Entities.Treatment;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

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
        public ICollection<TreatmentFiles> TreatmentFiles { get; set; }
    }

    public static class TreatmentInformationExtensions
    {
        public static GetTreatmentInformationEntity ToGetTreatmentInformationEntityEntityModel(this TreatmentInformation treatmentInformation)
        => treatmentInformation == null ? null : new GetTreatmentInformationEntity
        {
            Id = treatmentInformation.Id,
            PatientId = treatmentInformation.PatientId,
            Title = treatmentInformation.Title,
            Summary = treatmentInformation.Summary,
            TreatmentDate = treatmentInformation.Date,
            TreatmentFilesInformation = treatmentInformation.TreatmentFiles.Select(x => x.ToEntityModel()).ToList()
        };
    }
}

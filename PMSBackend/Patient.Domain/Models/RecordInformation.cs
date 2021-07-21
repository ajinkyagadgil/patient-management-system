using Patient.Core.Entities.Record;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Patient.Domain.Models
{
    [Table("RecordInformation", Schema ="Record")]
    public class RecordInformation
    {
        [Key]
        public Guid Id { get; set; }
        [ForeignKey("PatientInformation")]
        public Guid PatientId { get; set; }
        public virtual PatientInformation PatientInformation { get; set; }
        public string Treatment { get; set; }
        public int Amount { get; set; }
        public DateTime RecordDate { get; set; }
    }

    public static class RecordInformationExtensions
    {
        public static RecordInformationEntity ToModelEntity(this RecordInformation recordInformation)
        => recordInformation == null ? null : new RecordInformationEntity
        {
            Id = recordInformation.Id,
            PatientId = recordInformation.PatientId,
            Treatment = recordInformation.Treatment,
            Amount = recordInformation.Amount,
            RecordDate = recordInformation.RecordDate,
            PatientInformation = recordInformation.PatientInformation.ToModelEntity()
        };
    }
}

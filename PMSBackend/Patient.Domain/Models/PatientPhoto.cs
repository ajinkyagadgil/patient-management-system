using Patient.Core.Entities.Common;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Patient.Domain.Models
{
    [Table("PatientPhoto", Schema = "Patient")]
    public class PatientPhoto
    {
        [Key]
        public Guid Id { get; set; }

        [ForeignKey("PatientInformation")]
        public Guid PatientId { get; set; }
        public virtual PatientInformation PatientInformation { get; set; }
        public string Path { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
        public long Size { get; set; }
        public DateTime CreationDate { get; set; }
    }

    public static class PatientPhotoExtensions
    {
        public static FileInformationEntity ToEntityModel(this PatientPhoto patientPhoto)
        => patientPhoto == null ? null : new FileInformationEntity
        {
            Id = patientPhoto.Id,
            Path = patientPhoto.Path,
            Name = patientPhoto.Name,
            Type = patientPhoto.Type,
            Size = patientPhoto.Size,
            CreationDate = patientPhoto.CreationDate
        };
    }
}

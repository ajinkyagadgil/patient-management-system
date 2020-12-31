using Patient.Core.Common.Enums;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using PatientEntities = Patient.Core.Entities;

namespace Patient.Domain.Models
{
    [Table("PatientInformation", Schema = "Patient")]
    public class PatientInformation
    {
        [Key]
        public Guid Id { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public string Phone { get; set; }
        public int Gender { get; set; }
        public string History { get; set; }
        public string CaseNo { get; set; }
        public string PhotoPath { get; set; }
    }

    public static class PatientInformationExtension
    {
        public static PatientEntities.PatientInformationEntity ToModelEntity(this PatientInformation patientInformation)
        => patientInformation == null ? null : new PatientEntities.PatientInformationEntity
        {
            Id = patientInformation.Id,
            Name = patientInformation.Name,
            Age = patientInformation.Age,
            Phone = patientInformation.Phone,
            Gender = (Gender)patientInformation.Gender,
            History = patientInformation.History,
            CaseNo = patientInformation.CaseNo,
            PhotoPath = patientInformation.PhotoPath
        };
    }
}

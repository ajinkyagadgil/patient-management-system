using Patient.Core.Common.Enums;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using PatientEntities = Patient.Core.Entities.Patient;

namespace Patient.Domain.Models
{
    [Table("PatientInformation", Schema = "Patient")]
    public class PatientInformation
    {
        [Key]
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public int Age { get; set; }
        public string Phone { get; set; }
        public int Gender { get; set; }
        public string History { get; set; }
        public string CaseNo { get; set; }
        public virtual PatientPhoto PatientPhoto { get; set; }
    }

    public static class PatientInformationExtension
    {
        public static PatientEntities.PatientInformationBaseEntity ToModelEntity(this PatientInformation patientInformation)
        => patientInformation == null ? null : new PatientEntities.PatientInformationBaseEntity
        {
            Id = patientInformation.Id,
            FirstName = patientInformation.FirstName,
            LastName = patientInformation.LastName,
            Email = patientInformation.Email,
            Age = patientInformation.Age,
            Phone = patientInformation.Phone,
            Gender = (Gender)patientInformation.Gender,
            History = patientInformation.History,
            CaseNo = patientInformation.CaseNo
        };

        public static PatientEntities.GetPatientInformationEntity ToGetPatientInformationModelEntity(this PatientInformation patientInformation)
        => patientInformation == null ? null : new PatientEntities.GetPatientInformationEntity
        {
            Id = patientInformation.Id,
            FirstName = patientInformation.FirstName,
            LastName = patientInformation.LastName,
            Email = patientInformation.Email,
            Age = patientInformation.Age,
            Phone = patientInformation.Phone,
            Gender = (Gender)patientInformation.Gender,
            History = patientInformation.History,
            CaseNo = patientInformation.CaseNo,
            PatientPhotoInformation = patientInformation.PatientPhoto.ToEntityModel()
        };
    }
}

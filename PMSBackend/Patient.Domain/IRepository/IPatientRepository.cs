using Microsoft.AspNetCore.Http;
using Patient.Core.Entities;
using Patient.Core.Entities.Common;
using Patient.Core.Entities.Patient;
using Patient.Domain.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Patient.Domain.IRepository
{
    public interface IPatientRepository
    {
        Task<List<PatientInformation>> GetPatientsInformation();
        Task<PatientInformation> GetPatientInformation(Guid patientId);
        Task<Guid> SavePatientInformation(PostPatientInformationEntity postPatientInformationEntity);
        Task<bool> SavePatientPhoto(Guid patientId, FileInformationEntity patientPhoto);
        Task DeletePatientInformation(Guid patientId);
    }
}

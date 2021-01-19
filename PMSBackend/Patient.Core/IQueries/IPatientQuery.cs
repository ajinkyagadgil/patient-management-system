using Microsoft.AspNetCore.Http;
using Patient.Core.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Patient.Core.IQueries
{
    public interface IPatientQuery
    {
        Task<List<PatientInformationEntity>> GetPatientsInformation();
        Task<Guid> SavePatientInformation(PostPatientInformationEntity postPatientInformationEntity);
        Task<bool> SavePatientPhoto(Guid patientId, FileInformationEntity patientPhoto);
    }
}

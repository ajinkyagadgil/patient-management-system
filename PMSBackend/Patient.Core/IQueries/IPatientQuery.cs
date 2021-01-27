using Microsoft.AspNetCore.Http;
using Patient.Core.Entities;
using Patient.Core.Entities.Common;
using Patient.Core.Entities.Patient;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Patient.Core.IQueries
{
    public interface IPatientQuery
    {
        Task<List<GetPatientInformationEntity>> GetPatientsInformation();
        Task<GetPatientInformationEntity> GetPatientInformation(Guid patientId);
        Task<Guid> SavePatientInformation(PostPatientInformationEntity postPatientInformationEntity);
        Task<bool> SavePatientPhoto(Guid patientId, FileInformationEntity patientPhoto);
    }
}

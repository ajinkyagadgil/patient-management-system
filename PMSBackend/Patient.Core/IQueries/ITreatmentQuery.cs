using Patient.Core.Entities;
using Patient.Core.Entities.Common;
using Patient.Core.Entities.Treatment;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Patient.Core.IQueries
{
    public interface ITreatmentQuery
    {
        Task<List<GetTreatmentInformationEntity>> GetPatientTreatments(Guid patientId);
        Task<Guid> SaveTreatmentInformation(Guid patientId, PostTreatmentInformationEntity postTreatmentInformationEntity);
        Task<bool> SaveTreatmentFilesInformation(Guid treatmentId, List<FileInformationEntity> fileInformationEntityList);
    }
}

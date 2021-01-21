using Patient.Core.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Patient.Core.IQueries
{
    public interface ITreatmentQuery
    {
        Task<Guid> SaveTreatmentInformation(Guid patientId, PostTreatmentInformationEntity postTreatmentInformationEntity);
        Task<bool> SaveTreatmentFilesInformation(Guid treatmentId, List<FileInformationEntity> fileInformationEntityList);
    }
}

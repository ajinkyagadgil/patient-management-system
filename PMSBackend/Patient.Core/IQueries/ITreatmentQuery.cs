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
        Task<Guid> SaveTreatmentInformation(PostTreatmentInformationEntity postTreatmentInformationEntity);
        Task<bool> SaveTreatmentFilesInformation(Guid treatmentId, List<FileInformationEntity> fileInformationEntityList);
        Task<List<Guid>> DeleteTreatmentInformationByPatientId(Guid patientId);
        Task DeleteTreatmentInformationById(Guid treatmentId);
        Task<FileInformationEntity> DeleteTreatmentImage(Guid treatmentImageId);

    }
}

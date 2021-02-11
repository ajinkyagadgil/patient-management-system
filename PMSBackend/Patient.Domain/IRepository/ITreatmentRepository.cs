using Patient.Core.Entities.Common;
using Patient.Core.Entities.Treatment;
using Patient.Domain.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Patient.Domain.IRepository
{
    public interface ITreatmentRepository
    {
        Task<List<TreatmentInformation>> GetPatientTreatments(Guid patientId);
        Task<Guid> SaveTreatmentInformation(PostTreatmentInformationEntity postTreatmentInformationEntity);
        Task<bool> SaveTreatmentFilesInformation(Guid treatmentId, List<FileInformationEntity> fileInformationEntityList);
        Task<List<Guid>> DeleteTreatmentInformationByPatientId(Guid patientId);
    }
}

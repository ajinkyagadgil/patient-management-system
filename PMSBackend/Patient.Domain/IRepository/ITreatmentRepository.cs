using Patient.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Patient.Domain.IRepository
{
    public interface ITreatmentRepository
    {
        Task<Guid> SaveTreatmentInformation(Guid patientId, PostTreatmentInformationEntity postTreatmentInformationEntity);
        Task<bool> SaveTreatmentFilesInformation(Guid treatmentId, List<FileInformationEntity> fileInformationEntityList);
    }
}

using Patient.Core.Entities;
using Patient.Core.Entities.Common;
using Patient.Core.Entities.Treatment;
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

using Patient.Core.Entities;
using Patient.Core.Entities.Common;
using Patient.Core.Entities.Treatment;
using Patient.Core.IQueries;
using Patient.Domain.IRepository;
using Patient.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Patient.Domain.Queries
{
    public class TreatmentQuery : ITreatmentQuery
    {
        private readonly ITreatmentRepository _treatmentRepository;
        public TreatmentQuery(ITreatmentRepository treatmentRepository)
        {
            _treatmentRepository = treatmentRepository;
        }

        public async Task<List<GetTreatmentInformationEntity>> GetPatientTreatments(Guid patientId)
        {
            return (await _treatmentRepository.GetPatientTreatments(patientId)).Select(x => x.ToGetTreatmentInformationEntityEntityModel()).ToList();
        }

        public async Task<Guid> SaveTreatmentInformation(Guid patientId, PostTreatmentInformationEntity postTreatmentInformationEntity)
        {
            return await _treatmentRepository.SaveTreatmentInformation(patientId, postTreatmentInformationEntity);
        }

        public async Task<bool> SaveTreatmentFilesInformation(Guid treatmentId, List<FileInformationEntity> fileInformationEntityList)
        {
            return await _treatmentRepository.SaveTreatmentFilesInformation(treatmentId, fileInformationEntityList);
        }
    }
}

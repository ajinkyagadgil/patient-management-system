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
            return (await _treatmentRepository.GetPatientTreatments(patientId)).OrderByDescending(y => y.Date).Select(x => x.ToGetTreatmentInformationEntityEntityModel()).ToList();
        }

        public async Task<Guid> SaveTreatmentInformation(PostTreatmentInformationEntity postTreatmentInformationEntity)
        {
            return await _treatmentRepository.SaveTreatmentInformation(postTreatmentInformationEntity);
        }

        public async Task<bool> SaveTreatmentFilesInformation(Guid treatmentId, List<FileInformationEntity> fileInformationEntityList)
        {
            return await _treatmentRepository.SaveTreatmentFilesInformation(treatmentId, fileInformationEntityList);
        }

        public async Task<List<Guid>> DeleteTreatmentInformationByPatientId(Guid patientId)
        {
            return await _treatmentRepository.DeleteTreatmentInformationByPatientId(patientId);
        }

        public async Task DeleteTreatmentInformationById(Guid treatmentId)
        {
            await _treatmentRepository.DeleteTreatmentInformationById(treatmentId);
        }
    }
}

using Patient.Core.Entities;
using Patient.Data.Context;
using Patient.Domain.IRepository;
using Patient.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Patient.Data.Repository
{
    public class TreatmentRepository : ITreatmentRepository
    {
        private readonly PMSDBContext _pmsDBContext;
        public TreatmentRepository(PMSDBContext pmsDBContext)
        {
            _pmsDBContext = pmsDBContext;
        }

        public async Task<bool> SaveTreatmentFilesInformation(Guid treatmentId, List<FileInformationEntity> fileInformationEntityList)
        {
            var treatmentFilesInformation = new List<TreatmentFiles>();
            foreach (var file in fileInformationEntityList)
            {
                var treatmentFileInformation = new TreatmentFiles
                {
                    Id = Guid.NewGuid(),
                    TreatmentId = treatmentId,
                    Path = file.Path,
                    Name = file.Name,
                    Type = file.Type,
                    Size = file.Size,
                    CreationDate = DateTime.Now
                };
                treatmentFilesInformation.Add(treatmentFileInformation);
            }
            _pmsDBContext.TreatmentFiles.AddRange(treatmentFilesInformation);
            await _pmsDBContext.SaveChangesAsync();
            return true;
        }

        public async Task<Guid> SaveTreatmentInformation(Guid patientId, PostTreatmentInformationEntity postTreatmentInformationEntity)
        {
            if (postTreatmentInformationEntity.Id == Guid.Empty)
            {
                //Add
                var treatmentInformation = new TreatmentInformation
                {
                    Id = Guid.NewGuid(),
                    PatientId = patientId,
                    Title = postTreatmentInformationEntity.Title,
                    Summary = postTreatmentInformationEntity.Summary,
                    Date = postTreatmentInformationEntity.TreatmentDate
                };
                _pmsDBContext.TreatmentInformation.Add(treatmentInformation);
                await _pmsDBContext.SaveChangesAsync();
                return treatmentInformation.Id;
            }
            else
            {
                //Edit treatment information
                var result = _pmsDBContext.TreatmentInformation.Where(treatment => treatment.Id == postTreatmentInformationEntity.Id)
                                                               .SingleOrDefault();
                if (result != null)
                {
                    result.Title = postTreatmentInformationEntity.Title;
                    result.Summary = postTreatmentInformationEntity.Summary;
                    result.Date = postTreatmentInformationEntity.TreatmentDate;
                }
                await _pmsDBContext.SaveChangesAsync();
                return result.Id;
            }
        }
    }
}

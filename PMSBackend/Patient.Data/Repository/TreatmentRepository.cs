using Microsoft.EntityFrameworkCore;
using Patient.Core.Entities;
using Patient.Core.Entities.Common;
using Patient.Core.Entities.Treatment;
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

        public async Task<List<TreatmentInformation>> GetPatientTreatments(Guid patientId)
        {
            var treatmentInformation = await _pmsDBContext.TreatmentInformation.Include(x => x.TreatmentFiles).Where(x => x.PatientId == patientId).ToListAsync();
            return treatmentInformation;
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

        public async Task<Guid> SaveTreatmentInformation(PostTreatmentInformationEntity postTreatmentInformationEntity)
        {
            if (postTreatmentInformationEntity.Id == Guid.Empty)
            {
                //Add
                var treatmentInformation = new TreatmentInformation
                {
                    Id = Guid.NewGuid(),
                    PatientId = postTreatmentInformationEntity.PatientId,
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

        public async Task<List<Guid>> DeleteTreatmentInformationByPatientId(Guid patientId)
        {
            var treatmentInformation = await _pmsDBContext.TreatmentInformation.Where(x => x.PatientId == patientId).Include(x => x.TreatmentFiles).ToListAsync();
            var treatmentIds = treatmentInformation.Select(x => x.Id).ToList();
            if (treatmentInformation.Count > 0)
            {
                _pmsDBContext.RemoveRange(treatmentInformation);
                await _pmsDBContext.SaveChangesAsync();
            }
            return treatmentIds;
        }

        public async Task DeleteTreatmentInformationById(Guid treatmentId)
        {
            var treatmentInformation = await _pmsDBContext.TreatmentInformation.Where(x => x.Id == treatmentId).Include(x => x.TreatmentFiles).FirstOrDefaultAsync();
            if(treatmentInformation != null)
            {
                _pmsDBContext.Remove(treatmentInformation);
                await _pmsDBContext.SaveChangesAsync();
            }
        }

        public async Task<TreatmentFiles> DeleteTreatmentImage(Guid treatmentImageId)
        {
            var result = await _pmsDBContext.TreatmentFiles.Where(x => x.Id == treatmentImageId).FirstOrDefaultAsync();
            if(result != null)
            {
                _pmsDBContext.TreatmentFiles.Remove(result);
                await _pmsDBContext.SaveChangesAsync();
                return result;
            }
            else
            {
                throw new Exception("Image with id is not found");
            }
        }
    }
}

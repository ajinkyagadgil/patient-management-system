using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
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
    public class PatientRepository : IPatientRepository
    {
        private readonly PMSDBContext _pmsContext;
        public PatientRepository(PMSDBContext pmsContext)
        {
            _pmsContext = pmsContext;
        }

        public async Task<List<PatientInformation>> GetPatientsInformation()
        {
            return await _pmsContext.PatientsInformation.ToListAsync();
        }

        public async Task<Guid> SavePatientInformation(PostPatientInformationEntity postPatientInformationEntity)
        {
            if (postPatientInformationEntity.Id == Guid.Empty)
            {
                //Add information
                var patientInformation = new PatientInformation
                {
                    Id = Guid.NewGuid(),
                    FirstName = postPatientInformationEntity.FirstName,
                    LastName = postPatientInformationEntity.LastName,
                    Email = postPatientInformationEntity.Email,
                    Age = postPatientInformationEntity.Age,
                    Phone = postPatientInformationEntity.Phone,
                    Gender = (int)postPatientInformationEntity.Gender,
                    History = postPatientInformationEntity.History,
                    CaseNo = postPatientInformationEntity.CaseNo
                };
                _pmsContext.PatientsInformation.Add(patientInformation);
                await _pmsContext.SaveChangesAsync();
                return patientInformation.Id;
            }
            else
            {
                //Edit Information
                return Guid.NewGuid();
            }
        }

        public async Task<bool> SavePatientPhoto(Guid patientId, FileInformationEntity patientPhoto)
        {
            var result = _pmsContext.PatientPhoto.Where(x => x.Id == patientId).SingleOrDefault();
            if (result != null)
            {
                result.Path = patientPhoto.Path;
                result.Name = patientPhoto.Name;
                result.Type = patientPhoto.Type;
                result.Size = patientPhoto.Size;
                result.FileData = patientPhoto.FileData;
                await _pmsContext.SaveChangesAsync();
            }
            else
            {
                var patientPhotoData = new PatientPhoto
                {
                    Id = Guid.NewGuid(),
                    PatientId = patientId,
                    Path = patientPhoto.Path,
                    Name = patientPhoto.Name,
                    Type = patientPhoto.Type,
                    Size = patientPhoto.Size,
                    FileData = patientPhoto.FileData
                };
                _pmsContext.PatientPhoto.Add(patientPhotoData);
                await _pmsContext.SaveChangesAsync();
            }
            return true;
        }
    }
}

using Microsoft.EntityFrameworkCore;
using Patient.Core.Entities.Common;
using Patient.Core.Entities.Patient;
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
            return await _pmsContext.PatientsInformation.Include(x => x.PatientPhoto).ToListAsync();
        }

        public async Task<PatientInformation> GetPatientInformation(Guid patientId)
        {
            var res = await _pmsContext.PatientsInformation.Include(x => x.PatientPhoto).Where(x => x.Id == patientId).FirstOrDefaultAsync();
            return res;
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
                var patient = _pmsContext.PatientsInformation.Where(x => x.Id == postPatientInformationEntity.Id).SingleOrDefault();
                if(patient != null)
                {
                    patient.FirstName = postPatientInformationEntity.FirstName;
                    patient.LastName = postPatientInformationEntity.LastName;
                    patient.Email = postPatientInformationEntity.Email;
                    patient.Age = postPatientInformationEntity.Age;
                    patient.Phone = postPatientInformationEntity.Phone;
                    patient.Gender = (int)postPatientInformationEntity.Gender;
                    patient.History = postPatientInformationEntity.History;
                    patient.CaseNo = postPatientInformationEntity.CaseNo;
                }
                await _pmsContext.SaveChangesAsync();
                return patient.Id;
            }
        }

        public async Task<bool> SavePatientPhoto(Guid patientId, FileInformationEntity patientPhoto)
        {
            var result =  _pmsContext.PatientPhoto.Where(x => x.Id == patientId).SingleOrDefault();
            if (result != null)
            {
                result.Path = patientPhoto.Path;
                result.Name = patientPhoto.Name;
                result.Type = patientPhoto.Type;
                result.Size = patientPhoto.Size;
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
                    CreationDate = DateTime.Now
                };
                _pmsContext.PatientPhoto.Add(patientPhotoData);
                await _pmsContext.SaveChangesAsync();
            }
            return true;
        }
    }
}

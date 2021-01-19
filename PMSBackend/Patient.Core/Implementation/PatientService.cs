using Patient.Core.Entities;
using Patient.Core.IQueries;
using Patient.Core.Services;
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

namespace Patient.Core.Implementation
{
    public class PatientService : IPatientService
    {
        private readonly IPatientQuery _patientQuery;
        private readonly ITreatmentQuery _treatmentQuery;

        public PatientService(IPatientQuery patientQuery, ITreatmentQuery treatmentQuery)
        {
            _patientQuery = patientQuery;
            _treatmentQuery = treatmentQuery;
        }

        public async Task<List<PatientInformationEntity>> GetPatientsInformation()
        {
            return await _patientQuery.GetPatientsInformation();
        }

        public async Task SavePatientAndTreatmentInformation(PostPatientInformationEntity postPatientInformationEntity, PostTreatmentInformationEntity postTreatmentInformationEntity)
        {
            var patientId = await _patientQuery.SavePatientInformation(postPatientInformationEntity);
            if (patientId != null)
            {
                if (postPatientInformationEntity.PatientPhoto != null)
                {
                    var fileInformationEntity = new FileInformationEntity();
                    var patientImagesPath = Path.Combine(Directory.GetCurrentDirectory(), "Resources","PatientImages", patientId.ToString());
                    if (!Directory.Exists(patientImagesPath))
                    {
                        Directory.CreateDirectory(patientImagesPath);
                    }

                    string filePath = Path.Combine(patientImagesPath, postPatientInformationEntity.PatientPhoto.FileName);
                    using (var fileStream = new FileStream(filePath, FileMode.Create))
                    {
                        await postPatientInformationEntity.PatientPhoto.CopyToAsync(fileStream);
                        fileInformationEntity.Path = filePath;
                        fileInformationEntity.Name = postPatientInformationEntity.PatientPhoto.FileName;
                        fileInformationEntity.Type = postPatientInformationEntity.PatientPhoto.ContentType;

                    }
                    using (var ms = new MemoryStream())
                    {
                        await postPatientInformationEntity.PatientPhoto.CopyToAsync(ms);
                        var fileBytes = ms.ToArray();
                        fileInformationEntity.FileData = fileBytes;
                        // act on the Base64 data
                    }
                    var result = await _patientQuery.SavePatientPhoto(patientId, fileInformationEntity);
                }
            }
        }
    }
}

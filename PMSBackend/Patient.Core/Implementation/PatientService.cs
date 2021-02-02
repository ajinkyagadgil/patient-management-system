using Microsoft.AspNetCore.Http;
using Patient.Core.Entities.Patient;
using Patient.Core.Entities.Treatment;
using Patient.Core.Helpers;
using Patient.Core.IQueries;
using Patient.Core.Services;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
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

        public async Task<List<GetPatientInformationEntity>> GetPatientsInformation()
        {
            return await _patientQuery.GetPatientsInformation();
        }

        public async Task<GetPatientInformationEntity> GetPatientInformation(Guid patientId)
        {
            return await _patientQuery.GetPatientInformation(patientId);
        }

        public async Task SavePatientAndTreatmentInformation(PostPatientInformationEntity postPatientInformationEntity, PostTreatmentInformationEntity postTreatmentInformationEntity)
        {
            var patientId = await _patientQuery.SavePatientInformation(postPatientInformationEntity);
            Fileuploader fileuploader = new Fileuploader();
            if (postPatientInformationEntity.PatientPhoto != null)
            {
                List<IFormFile> patientPhoto = new List<IFormFile>
                    {
                        postPatientInformationEntity.PatientPhoto,
                    };
                var uploadedFileData = await fileuploader.UploadFiles(patientPhoto, Common.Enums.FileUploadType.Patient, patientId);
                var savePatientPhotoInformationResult = await _patientQuery.SavePatientPhoto(patientId, uploadedFileData.FirstOrDefault());
                var treatmentId = await _treatmentQuery.SaveTreatmentInformation(postTreatmentInformationEntity);
                var uploadTreatmentFilesResult = await fileuploader.UploadFiles(postTreatmentInformationEntity.TreatmentFiles, Common.Enums.FileUploadType.Treatment, treatmentId);
                var saveTreatmentFilesInformationResult = await _treatmentQuery.SaveTreatmentFilesInformation(treatmentId, uploadTreatmentFilesResult);
            }
        }

        public async Task SavePatientInformation(PostPatientInformationEntity postPatientInformationEntity)
        {
            var patientId = await _patientQuery.SavePatientInformation(postPatientInformationEntity);
            if (postPatientInformationEntity.PatientPhoto != null)
            {
                Fileuploader fileuploader = new Fileuploader();
                List<IFormFile> patientPhoto = new List<IFormFile>
                    {
                        postPatientInformationEntity.PatientPhoto,
                    };
                var uploadedFileData = await fileuploader.UploadFiles(patientPhoto, Common.Enums.FileUploadType.Patient, patientId);
                await _patientQuery.SavePatientPhoto(patientId, uploadedFileData.FirstOrDefault());
            }
        }
    }
}

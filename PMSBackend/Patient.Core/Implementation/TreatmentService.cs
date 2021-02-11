using Patient.Core.Entities.Treatment;
using Patient.Core.Helpers;
using Patient.Core.IQueries;
using Patient.Core.Services;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Patient.Core.Implementation
{
    public class TreatmentService : ITreatmentService
    {
        private readonly ITreatmentQuery _treatmentQuery;
        public TreatmentService(ITreatmentQuery treatmentQuery)
        {
            _treatmentQuery = treatmentQuery;
        }

        public async Task<List<GetTreatmentInformationEntity>> GetPatientTreatments(Guid patientId)
        {
            return (await _treatmentQuery.GetPatientTreatments(patientId));
        }

        public async Task SavePatientTreatment(PostTreatmentInformationEntity postTreatmentInformationEntity)
        {
            var treatmentId = await _treatmentQuery.SaveTreatmentInformation(postTreatmentInformationEntity);
            if (postTreatmentInformationEntity.TreatmentFiles != null)
            {
                FileHelper fileuploader = new FileHelper();
                var uploadedFileData = await fileuploader.UploadFiles(postTreatmentInformationEntity.TreatmentFiles, Common.Enums.FileUploadType.Treatment, treatmentId);
                await _treatmentQuery.SaveTreatmentFilesInformation(treatmentId, uploadedFileData);
            }
        }
    }
}

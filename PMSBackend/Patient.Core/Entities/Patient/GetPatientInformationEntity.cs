using Patient.Core.Entities.Common;

namespace Patient.Core.Entities.Patient
{
    public class GetPatientInformationEntity: PatientInformationBaseEntity
    {
        public FileInformationEntity PatientPhotoInformation { get; set; }
    }
}

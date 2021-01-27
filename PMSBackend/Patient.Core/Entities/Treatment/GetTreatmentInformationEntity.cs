using Patient.Core.Entities.Common;

namespace Patient.Core.Entities.Treatment
{
    public class GetTreatmentInformationEntity: TreatmentInformationBaseEntity
    {
        public FileInformationEntity TreatmentFilesInformation { get; set; }
    }
}

using Patient.Core.Entities.Common;
using System.Collections.Generic;

namespace Patient.Core.Entities.Treatment
{
    public class GetTreatmentInformationEntity: TreatmentInformationBaseEntity
    {
        public List<FileInformationEntity> TreatmentFilesInformation { get; set; }
    }
}

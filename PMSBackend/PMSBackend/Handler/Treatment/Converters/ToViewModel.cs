using Patient.Core.Entities.Common;
using Patient.Core.Entities.Treatment;
using PMSBackend.Handler.Patient.ViewModels;
using System.Linq;

namespace PMSBackend.Handler.Treatment.Converters
{
    public static class ToViewModels
    {
        public static GetTreatmentInformationViewModel ToViewModel(this GetTreatmentInformationEntity getTreatmentInformationEntity)
        => getTreatmentInformationEntity == null ? null : new GetTreatmentInformationViewModel
        {
            id = getTreatmentInformationEntity.Id,
            title = getTreatmentInformationEntity.Title,
            summary = getTreatmentInformationEntity.Summary,
            treatmentDate = getTreatmentInformationEntity.TreatmentDate,
            treatmentFilesInformation = getTreatmentInformationEntity.TreatmentFilesInformation.Select(x => x.ToViewModel()).ToList()
        };

        public static FileInformationViewModel ToViewModel(this FileInformationEntity fileInformationEntity)
        => fileInformationEntity == null ? null : new FileInformationViewModel
        {
            id = fileInformationEntity.Id,
            name = fileInformationEntity.Name,
            path = fileInformationEntity.Path,
            size = fileInformationEntity.Size,
            type = fileInformationEntity.Type,
            creationDate = fileInformationEntity.CreationDate
        };
    }
}

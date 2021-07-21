using Patient.Core.Common.Enums;
using Patient.Core.Entities.Common;
using PMSBackend.Handler.Common.ViewModels;
using PMSBackend.Handler.Patient.ViewModels;

namespace PMSBackend.Handler.Common.Converters
{
    public static class ToViewModels
    {
        public static GenderViewModel ToViewModel(this Gender gender)
        => gender < 0 ? null : new GenderViewModel
        {
            id = (int)gender,
            name = gender.ToString()
        };

        public static FileInformationViewModel ToViewModel(this FileInformationEntity fileInformationEntity)
        => fileInformationEntity == null ? null : new FileInformationViewModel
        {
            id = fileInformationEntity.Id,
            path = fileInformationEntity.Path,
            name = fileInformationEntity.Name,
            type = fileInformationEntity.Type,
            size = fileInformationEntity.Size,
            creationDate = fileInformationEntity.CreationDate
        };
    }
}

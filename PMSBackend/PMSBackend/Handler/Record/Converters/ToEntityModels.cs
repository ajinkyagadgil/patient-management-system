using Patient.Core.Entities.Record;
using PMSBackend.Handler.Patient.Converters;
using PMSBackend.Handler.Record.ViewModels;

namespace PMSBackend.Handler.Record.Converters
{
    public static class ToEntityModels
    {
        public static RecordInformationEntity ToEntityModel(this RecordInformationViewModel recordInformationViewModel)
        => recordInformationViewModel == null ? null : new RecordInformationEntity
        {
            Id = recordInformationViewModel.id,
            PatientId = recordInformationViewModel.patientId,
            Amount = recordInformationViewModel.amount,
            Treatment = recordInformationViewModel.treatment,
            RecordDate = recordInformationViewModel.recordDate,
            PatientInformation = recordInformationViewModel.PatientInformation.ToEntityModel()
        };

        public static DateRangeEntity ToEntityModel(this DateRangeViewModel dateRangeViewModel)
        => dateRangeViewModel == null ? null : new DateRangeEntity
        {
            StartDate = dateRangeViewModel.startDate,
            EndDate = dateRangeViewModel.endDate
        };
    }
}

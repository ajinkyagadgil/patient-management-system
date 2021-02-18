using Patient.Core.Entities.Record;
using PMSBackend.Handler.Patient.Converters;
using PMSBackend.Handler.Record.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PMSBackend.Handler.Record.Converters
{
    public static class ToViewModels
    {
        public static RecordInformationViewModel ToViewModel(this RecordInformationEntity recordInformatonEntity)
        => recordInformatonEntity == null ? null : new RecordInformationViewModel
        {
            id = recordInformatonEntity.Id,
            patientId = recordInformatonEntity.PatientId,
            treatment = recordInformatonEntity.Treatment,
            amount = recordInformatonEntity.Amount,
            recordDate = recordInformatonEntity.RecordDate,
            PatientInformation = recordInformatonEntity.PatientInformation.ToViewModel()
        };
    }
}

using System.Collections.Generic;

namespace PMSBackend.Handler.Patient.ViewModels
{
    public class GetTreatmentInformationViewModel: TreatmentInformationBaseViewModel
    {
        public List<FileInformationViewModel> treatmentFiles { get; set; }
    }
}

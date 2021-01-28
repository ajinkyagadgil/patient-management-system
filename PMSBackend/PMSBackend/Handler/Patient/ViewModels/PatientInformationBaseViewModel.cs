using Patient.Core.Common.Enums;
using PMSBackend.Handler.Common.ViewModels;
using System;

namespace PMSBackend.Handler.Patient.ViewModels
{
    public class PatientInformationBaseViewModel
    {
        public Guid id { get; set; }
        public string firstName { get; set; }
        public string lastName { get; set; }
        public string email { get; set; }
        public int age { get; set; }
        public string phone { get; set; }
        public Gender gender { get; set; }
        public string history { get; set; }
        public string caseNo { get; set; }
    }
}

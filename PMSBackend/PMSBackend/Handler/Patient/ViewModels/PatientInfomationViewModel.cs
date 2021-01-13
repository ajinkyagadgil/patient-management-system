using Patient.Core.Common.Enums;
using PMSBackend.Handler.Common.ViewModels;
using System;

namespace PMSBackend.Handler.Patient.ViewModels
{
    public class PatientInfomationViewModel
    {
        public Guid id { get; set; }
        public string fullName { get; set; }
        public string email { get; set; }
        public int age { get; set; }
        public string phone { get; set; }
        public GenderViewModel gender { get; set; }
        public string history { get; set; }
        public string caseNo { get; set; }
        public string photoPath { get; set; }
    }
}

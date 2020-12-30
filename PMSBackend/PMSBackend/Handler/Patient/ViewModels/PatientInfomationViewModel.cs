using Patient.Core.Common.Enums;
using System;

namespace PMSBackend.Handler.Patient.ViewModels
{
    public class PatientInfomationViewModel
    {
        public Guid id { get; set; }
        public string name { get; set; }
        public int age { get; set; }
        public string phone { get; set; }
        public Gender gender { get; set; }
        public string history { get; set; }
        public string caseNo { get; set; }
        public string photoPath { get; set; }
    }
}

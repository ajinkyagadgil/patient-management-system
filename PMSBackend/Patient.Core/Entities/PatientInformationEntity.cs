using Patient.Core.Common.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace Patient.Core.Entities
{
    public class PatientInformationEntity
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public int Age { get; set; }
        public string Phone { get; set; }
        public Gender Gender { get; set; }
        public string History { get; set; }
        public string CaseNo { get; set; }
        public string PhotoPath { get; set; }
    }
}

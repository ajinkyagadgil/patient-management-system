using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;

namespace Patient.Core.Entities
{
    public class PostTreatmentInformationEntity
    {
        public string Title { get; set; }
        public string Summary { get; set; }
        public DateTime TreatmentDate { get; set; }
        public List<IFormFile> TreatmentFiles { get; set; }
    }
}

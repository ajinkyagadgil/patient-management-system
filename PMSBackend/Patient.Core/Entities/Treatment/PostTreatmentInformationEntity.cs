using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;

namespace Patient.Core.Entities.Treatment
{
    public class PostTreatmentInformationEntity: TreatmentInformationBaseEntity
    {
        public List<IFormFile> TreatmentFiles { get; set; }
    }
}

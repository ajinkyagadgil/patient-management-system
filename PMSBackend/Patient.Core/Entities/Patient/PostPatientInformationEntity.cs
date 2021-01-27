using Microsoft.AspNetCore.Http;

namespace Patient.Core.Entities.Patient
{
    public class PostPatientInformationEntity: PatientInformationBaseEntity
    {
        public IFormFile PatientPhoto { get; set; }
    }
}

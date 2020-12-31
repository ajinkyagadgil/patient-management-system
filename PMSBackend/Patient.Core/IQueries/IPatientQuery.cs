using Patient.Core.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Patient.Core.IQueries
{
    public interface IPatientQuery
    {
        Task<List<PatientInformationEntity>> GetPatientsInformation();
    }
}

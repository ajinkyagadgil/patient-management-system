using Patient.Domain.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Patient.Domain.IRepository
{
    public interface IPatientRepository
    {
        Task<List<PatientInformation>> GetPatientsInformation();
    }
}

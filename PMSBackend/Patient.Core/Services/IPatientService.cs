using Patient.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Patient.Core.Services
{
    public interface IPatientService
    {
        Task<List<PatientInformation>> GetPatientsInformation();
    }
}

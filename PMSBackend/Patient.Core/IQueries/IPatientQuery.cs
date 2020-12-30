using Patient.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Patient.Core.IQueries
{
    public interface IPatientQuery
    {
        Task<List<PatientInformation>> GetPatientsInformation();
    }
}

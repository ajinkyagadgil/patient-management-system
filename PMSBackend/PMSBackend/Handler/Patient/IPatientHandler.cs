using PMSBackend.Handler.Patient.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PMSBackend.Handler.Patient
{
    public interface IPatientHandler
    {
        Task<List<PatientInfomationViewModel>> GetPatientsInformation();
    }
}

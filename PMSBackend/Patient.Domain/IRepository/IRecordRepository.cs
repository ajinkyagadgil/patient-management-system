using Patient.Core.Entities.Record;
using Patient.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Patient.Domain.IRepository
{
    public interface IRecordRepository
    {
        Task<List<RecordInformation>> GetAllRecords(DateRangeEntity dateRangeEntity);
        Task SaveRecord(RecordInformationEntity recordInformationEntity);
        Task DeleteRecord(Guid recordId);
        Task DeleteRecordByPatientId(Guid patientId);
    }
}

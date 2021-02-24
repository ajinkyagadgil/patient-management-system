using Patient.Core.Entities.Record;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Patient.Core.IQueries
{
    public interface IRecordQuery
    {
        Task<List<RecordInformationEntity>> GetAllRecords();
        Task SaveRecord(RecordInformationEntity recordInformationEntity);
        Task DeleteRecord(Guid recordId);
    }
}

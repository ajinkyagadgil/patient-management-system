using Patient.Core.Entities.Record;
using Patient.Core.IQueries;
using Patient.Core.Services;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Patient.Core.Implementation
{
    public class RecordService : IRecordService
    {
        private readonly IRecordQuery _recordQuery;

        public RecordService(IRecordQuery recordQuery)
        {
            _recordQuery = recordQuery;
        }

        public async Task<List<RecordInformationEntity>> GetAllRecords(DateRangeEntity dateRangeEntity)
        {
            return await _recordQuery.GetAllRecords(dateRangeEntity);
        }

        public async Task SaveRecord(RecordInformationEntity recordInformationEntity)
        {
            await _recordQuery.SaveRecord(recordInformationEntity);
        }

        public async Task DeleteRecord(Guid recordId)
        {
            await _recordQuery.DeleteRecord(recordId);
        }
    }
}

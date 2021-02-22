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

        public async Task<List<RecordInformationEntity>> GetAllRecords()
        {
            return await _recordQuery.GetAllRecords();
        }

        public async Task SaveRecord(RecordInformationEntity recordInformationEntity)
        {
            await _recordQuery.SaveRecord(recordInformationEntity);
        }
    }
}

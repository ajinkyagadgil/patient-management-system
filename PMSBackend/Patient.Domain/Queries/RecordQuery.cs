using Patient.Core.Entities.Record;
using Patient.Core.IQueries;
using Patient.Domain.IRepository;
using Patient.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Patient.Domain.Queries
{
    public class RecordQuery : IRecordQuery
    {
        private readonly IRecordRepository _recordRepository;

        public RecordQuery(IRecordRepository recordRepository)
        {
            _recordRepository = recordRepository;
        }

        public async Task<List<RecordInformationEntity>> GetAllRecords(DateRangeEntity dateRangeEntity)
        {
            try
            {
                return (await _recordRepository.GetAllRecords(dateRangeEntity)).Select(x => x.ToModelEntity()).ToList();
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task SaveRecord(RecordInformationEntity recordInformationEntity)
        {
            await _recordRepository.SaveRecord(recordInformationEntity);
        }

        public async Task DeleteRecord(Guid recordId)
        {
            await _recordRepository.DeleteRecord(recordId);
        }

        public async Task DeleteRecordByPatientId(Guid patientId)
        {
            await _recordRepository.DeleteRecordByPatientId(patientId);
        }
    }
}

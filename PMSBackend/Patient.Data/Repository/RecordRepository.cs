using Microsoft.EntityFrameworkCore;
using Patient.Core.Entities.Record;
using Patient.Data.Context;
using Patient.Domain.IRepository;
using Patient.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Patient.Data.Repository
{
    public class RecordRepository : IRecordRepository
    {
        private readonly PMSDBContext _pmsDBContext;

        public RecordRepository(PMSDBContext pmsDBContext)
        {
            _pmsDBContext = pmsDBContext;
        }

        public async Task<List<RecordInformation>> GetAllRecords()
        {
            return await _pmsDBContext.RecordInformation.Include(x => x.PatientInformation).ToListAsync();
        }

        public async Task SaveRecord(RecordInformationEntity recordInformationEntity)
        {
            var result = await _pmsDBContext.RecordInformation.Where(x => x.Id == recordInformationEntity.Id).FirstOrDefaultAsync();
            if (result == null)
            {
                var recordInformation = new RecordInformation
                {
                    Id = Guid.NewGuid(),
                    PatientId = recordInformationEntity.PatientId,
                    Amount = recordInformationEntity.Amount,
                    Treatment = recordInformationEntity.Treatment,
                    RecordDate = recordInformationEntity.RecordDate
                };
                _pmsDBContext.RecordInformation.Add(recordInformation);
            }
            else
            {
                result.PatientId = recordInformationEntity.PatientId;
                result.Treatment = recordInformationEntity.Treatment;
                result.Amount = recordInformationEntity.Amount;
                result.RecordDate = recordInformationEntity.RecordDate;
            }
            await _pmsDBContext.SaveChangesAsync();
        }

        public async Task DeleteRecord(Guid recordId)
        {
            var result = await _pmsDBContext.RecordInformation.Where(x => x.Id == recordId).FirstOrDefaultAsync();
            if (result != null)
            {
                _pmsDBContext.RecordInformation.Remove(result);
                await _pmsDBContext.SaveChangesAsync();
            }
            else
            {
                throw new Exception("Record not found");
            }
        }
    }
}

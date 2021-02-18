using Microsoft.EntityFrameworkCore;
using Patient.Data.Context;
using Patient.Domain.IRepository;
using Patient.Domain.Models;
using System.Collections.Generic;
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
    }
}

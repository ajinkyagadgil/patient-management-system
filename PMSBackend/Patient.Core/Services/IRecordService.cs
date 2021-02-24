﻿using Patient.Core.Entities.Record;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Patient.Core.Services
{
    public interface IRecordService
    {
        Task<List<RecordInformationEntity>> GetAllRecords();
        Task SaveRecord(RecordInformationEntity recordInformationEntity);
        Task DeleteRecord(Guid recordId);
    }
}

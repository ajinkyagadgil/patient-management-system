using PMSBackend.Handler.Record.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PMSBackend.Handler.Record
{
    public interface IRecordHandler
    {
        Task<List<RecordInformationViewModel>> GetAllRecords();
    }
}

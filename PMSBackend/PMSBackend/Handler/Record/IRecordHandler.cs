using PMSBackend.Handler.Record.ViewModels;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PMSBackend.Handler.Record
{
    public interface IRecordHandler
    {
        Task<List<RecordInformationViewModel>> GetAllRecords();
        Task SaveRecord(RecordInformationViewModel recordInformationViewModel);
    }
}

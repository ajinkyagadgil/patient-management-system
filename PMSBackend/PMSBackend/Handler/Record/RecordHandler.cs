using Patient.Core.Services;
using PMSBackend.Handler.Record.Converters;
using PMSBackend.Handler.Record.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PMSBackend.Handler.Record
{
    public class RecordHandler : IRecordHandler
    {
        private readonly IRecordService _recordService;

        public RecordHandler(IRecordService recordService)
        {
            _recordService = recordService;
        }

        public async Task<List<RecordInformationViewModel>> GetAllRecords()
        {
            return (await _recordService.GetAllRecords()).Select(x => x.ToViewModel()).ToList();
        }
    }
}

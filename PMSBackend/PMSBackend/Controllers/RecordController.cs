using Microsoft.AspNetCore.Mvc;
using PMSBackend.Handler.Record;
using PMSBackend.Handler.Record.ViewModels;
using System;
using System.Threading.Tasks;

namespace PMSBackend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RecordController : ControllerBase
    {
        private readonly IRecordHandler _recordHandler;

        public RecordController(IRecordHandler recordHandler)
        {
            _recordHandler = recordHandler;
        }

        [Route("all")]
        [HttpGet]
        public async Task<IActionResult> GetAllRecords()
        {
            try
            {
                return Ok(await _recordHandler.GetAllRecords());
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        [Route("save")]
        [HttpPost]
        public async Task<IActionResult> SaveRecord([FromBody] RecordInformationViewModel recordInformationViewModel)
        {
            try
            {
                await _recordHandler.SaveRecord(recordInformationViewModel);
                return Ok();
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        [Route("delete/{recordId}")]
        [HttpDelete]
        public async Task<IActionResult> DeleteRecord([FromRoute]Guid recordId)
        {
            try
            {
                await _recordHandler.DeleteRecord(recordId);
                return Ok();
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}

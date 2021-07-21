using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
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
        private readonly ILogger<RecordController> _logger;

        public RecordController(IRecordHandler recordHandler, ILogger<RecordController> logger)
        {
            _recordHandler = recordHandler;
            _logger = logger;
        }

        [Route("all")]
        [HttpPost]
        public async Task<IActionResult> GetAllRecords([FromBody]DateRangeViewModel dateRangeViewModel)
        {
            try
            {
                return Ok(await _recordHandler.GetAllRecords(dateRangeViewModel));
            }
            catch(Exception ex)
            {
                _logger.LogError(ex, ex.Message, null);
                return BadRequest("Some error occured while fetching the records.");
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
                _logger.LogError(ex, ex.Message, null);
                return BadRequest("Some error occured while saving record.");
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
                _logger.LogError(ex, ex.Message, null);
                return BadRequest("Some error occured while deleting record.");
            }
        }
    }
}

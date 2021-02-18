using Microsoft.AspNetCore.Mvc;
using PMSBackend.Handler.Record;
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
    }
}

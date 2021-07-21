using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using PMSBackend.Handler.Common;

namespace PMSBackend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CommonController : ControllerBase
    {
        private readonly ICommonHandler _commonHandler;
        private readonly ILogger<CommonController> _logger;
        public CommonController(ICommonHandler commonHandler, ILogger<CommonController> logger)
        {
            _commonHandler = commonHandler;
            _logger = logger;
        }

        [Route("genders")]
        [HttpGet]
        public IActionResult GetGenders()
        {
            try
            {
                return Ok(_commonHandler.GetGenders());
            }
            catch(Exception ex)
            {
                _logger.LogError(ex, ex.Message, null);
                return BadRequest("Some error occured while fetching genders.");
            }
        }
    }
}
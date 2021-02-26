using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PMSBackend.Handler.Common;

namespace PMSBackend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CommonController : ControllerBase
    {
        private readonly ICommonHandler _commonHandler;
        public CommonController(ICommonHandler commonHandler)
        {
            _commonHandler = commonHandler;
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
                return BadRequest(ex.Message);
            }
        }
    }
}
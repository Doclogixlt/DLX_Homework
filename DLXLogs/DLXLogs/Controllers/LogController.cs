using DataAccess.Models.LogModels;
using DataAccess.Models.RequestModels;
using DLXLogsBL.Contracts;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DLXLogs.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class LogController : Controller
    {
        private readonly ILogService _logService;

        public LogController(ILogService logService)
        {
            _logService = logService;
        }

        [Authorize]
        [HttpPost(Name = "upload")]
        public async Task<IActionResult> Upload(IFormFile file)
        {
            if(file != null)
            {
                await _logService.AddLogs(file);
                return Ok();
            }
            return BadRequest();
        }

        [Authorize]
        [HttpPost(Name = "get")]
        public async Task<IActionResult> Get([FromQuery]LogRequestModel parameters)
        {
            var logs = await _logService.GetLogs(parameters.LogFilter, parameters.Pagination);
            return Ok(logs);
        }
    }
}

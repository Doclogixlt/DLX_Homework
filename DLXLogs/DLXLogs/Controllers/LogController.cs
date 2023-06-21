using DataAccess.Models.LogModels;
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
        [HttpGet(Name = "get")]
        public async Task<IActionResult> Get([FromQuery]LogFilter filter, [FromQuery] Pagination pagination)
        {
            var logs = await _logService.GetLogs(filter, pagination);
            return Ok(logs);
        }
    }
}

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace LogView.Controllers
{
    [Route("[controller]/[action]")]
    [ApiController]
    public class LogController : Controller
    {

        [Authorize]
        [HttpGet]
        public IActionResult Get()
        {
            return Json("Logs");
        }
    }
}

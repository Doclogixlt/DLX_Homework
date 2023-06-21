using DataAccess.Models.UserModels;
using DLXLogsBL.Contracts;
using Microsoft.AspNetCore.Mvc;

namespace DLXLogs.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class AuthController : ControllerBase
    {

        private readonly ILogger<AuthController> _logger;
        private readonly IAuthenticationService _authService;

        public AuthController(ILogger<AuthController> logger, IAuthenticationService authService)
        {
            _logger = logger;
            _authService = authService;
        }

        [HttpPost(Name = "register")]
        public async Task<IActionResult> Register(RegisterModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                var result = await _authService.Register(model);

                if (result != null)
                {
                    return Ok();
                }

                return BadRequest();
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpPost(Name = "login")]
        public async Task<IActionResult> Login(LoginModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var token = await _authService.Login(model);

            if (token != null)
            {
                return Ok(new {token = token});
            }

            return BadRequest();
        }
    }
}
using BusinessLogic.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Models.UserModels;

namespace LogView.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class AuthController : ControllerBase
    {
        private readonly IAuthenticationService _authenticationService;

        public AuthController(IAuthenticationService authenticationService)
        {
            _authenticationService = authenticationService;
        }

        [HttpPost]
        public async Task<IActionResult> Register(RegisterModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var result = _authenticationService.Register(model);

            if (result != null)
            {
                return Ok();
            }

            return BadRequest();
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginModel model)
        {

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var token = await _authenticationService.Login(model);

            if (token != null)
            {
                return Ok(token);
            }

            return BadRequest(new { message = "User login unsuccessful" });
        }
    }
}
using Microsoft.AspNetCore.Mvc;
using schoolattendance_api.Dtos.Auth;
using schoolattendance_api.Dtos.User;
using schoolattendance_api.Services.Auth;

namespace schoolattendance_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private IAuthService _authService;

        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }

        [HttpPost("Login")]
        public async Task<ActionResult<AuthResponseDto>> Login(AuthDto authLoginDto)
        {
            var response = await _authService.Login(authLoginDto);
            return Ok(response);
        }

        [HttpPost("Register")]
        public async Task<ActionResult<AuthResponseDto>> Register(UserInsertDto authRegisterDto)
        {
            var response = await _authService.Register(authRegisterDto);
            return Ok(response);
        }
    }
}

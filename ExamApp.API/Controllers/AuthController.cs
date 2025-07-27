using ExamApp.Application.Dtos.Auth;
using ExamApp.Application.Interfaces.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ExamApp.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;
        private readonly IStudentRegisterationService _studentRegisterationService;

        public AuthController(IAuthService authService,
            IStudentRegisterationService studentRegisterationService)
        {
            _authService = authService;
            _studentRegisterationService = studentRegisterationService;
        }


        [HttpPost("/api/student/register")]
        public async Task<IActionResult> Register(RegisterDto dto)
        {
            var response = await _studentRegisterationService.RegisterStudentAsync(dto);
            return Ok(response);
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login(LoginDto dto)
        {
            var response = await _authService.LoginAsync(dto);

            if (!response.Success)
                return BadRequest(response.Errors);

            return Ok(response);
        }

    }
}

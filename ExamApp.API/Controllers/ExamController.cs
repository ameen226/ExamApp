using ExamApp.Application.Dtos.Exam;
using ExamApp.Application.Interfaces.Services;
using ExamApp.Domain.Enums;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace ExamApp.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ExamController : ControllerBase
    {
        private readonly IExamService _examService;

        public ExamController(IExamService examService)
        {
            _examService = examService;
        }


        [Authorize(Roles = "student")]
        [HttpPost("/api/me/exam/request")]
        public async Task<IActionResult> RequestExam([FromBody] CreateExamDto dto)
        {
            var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            var response = await _examService.RequestExamAsync(dto, userId);

            if (!response.Success)
                return BadRequest(response.Errors);

            return Ok(response.Data);
        }
    }
}

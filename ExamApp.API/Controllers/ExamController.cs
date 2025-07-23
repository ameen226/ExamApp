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
            var studentId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            var response = await _examService.RequestExamAsync(dto, studentId);

            if (!response.Success)
                return BadRequest(response.Errors);

            return Ok(response.Data);
        }

        [Authorize(Roles = "student")]
        [HttpPost("/api/me/exam/{examId}/submit")]
        public async Task<IActionResult> SubmitExam(int examId, [FromBody] SubmitExamDto dto)
        {
            if (dto == null)
                return BadRequest();

            var studentId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;

            var response = await _examService.SubmitExamAsync(examId, studentId, dto);

            if (!response.Success)
                return BadRequest(response.Errors[0]);

            return Ok();
        }

    }
}

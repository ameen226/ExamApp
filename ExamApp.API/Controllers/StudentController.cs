using ExamApp.Application.Common.Models;
using ExamApp.Application.Dtos.Student;
using ExamApp.Application.Interfaces.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace ExamApp.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private readonly IStudentService _studentService;

        public StudentController(IStudentService studentService)
        {
            _studentService = studentService;
        }

        [HttpGet]
        [Authorize(Roles = "admin")]

        public async Task<IActionResult> GetAllStudents([FromQuery] PaginationParameters pagination)
        {
            Console.WriteLine($"Authorization header: {Request.Headers["Authorization"]}");
            var res = await _studentService.GetAllStudentsAsync(pagination);
            return Ok(res.Data);
        }


        [HttpPut("{id}/status")]
        [Authorize(Roles = "admin")]

        public async Task<IActionResult> UpdateStatus(string id, [FromBody] UpdateStudentStatusDto dto)
        {
            var res = await _studentService.UpdateStudentStatusAsync(id, dto.Enabled);

            if (!res.Success)
                return BadRequest(res.Errors[0]);

            return Ok(res.Message);
        }

        [HttpGet("me/subjects")]
        [Authorize(Roles = "student")]

        public async Task<IActionResult> GetAllStudentSubject()
        {
            var studentId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            var response = await _studentService.GetAllStudentSubjectsAsync(studentId);

            if (!response.Success)
                return BadRequest(response.Errors[0]);

            return Ok(response.Data);
        }


        [HttpPost("me/subjects")]
        [Authorize(Roles = "student")]

        public async Task<IActionResult> AddStudentSubject([FromBody] AssignSubjectDto dto)
        {
            var studentId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;

            var response = await _studentService.AddStudentSubjectAsync(studentId, dto.SubjectId);

            if (!response.Success)
                return BadRequest(response.Errors[0]);

            return Ok(response.Message);
        }

    }
}

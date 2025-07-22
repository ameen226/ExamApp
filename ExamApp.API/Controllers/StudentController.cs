using ExamApp.Application.Dtos.Student;
using ExamApp.Application.Interfaces.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

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
        public async Task<IActionResult> GetAllStudents()
        {
            Console.WriteLine($"Authorization header: {Request.Headers["Authorization"]}");
            var res = await _studentService.GetAllStudentsAsyn();
            return Ok(res.Data);
        }


        [HttpPut("{id}/status")]
        public async Task<IActionResult> UpdateStatus(string id, [FromBody] UpdateStudentStatusDto dto)
        {
            var res = await _studentService.UpdateStudentStatusAsync(id, dto.Enabled);

            if (!res.Success)
                return BadRequest(res.Errors[0]);

            return Ok(res.Message);
        }

        [HttpGet("{id}/subjects")]
        public async Task<IActionResult> GetAllStudentSubject(string id)
        {
            var response = await _studentService.GetAllStudentSubjectsAsync(id);

            if (!response.Success)
                return BadRequest(response.Errors[0]);

            return Ok(response.Data);
        }


        [HttpPost("{id}/subjects")]
        public async Task<IActionResult> AddStudentSubject(string id,[FromBody] AssignSubjectDto dto)
        {
            var response = await _studentService.AddStudentSubjectAsync(id, dto.SubjectId);

            if (!response.Success)
                return BadRequest(response.Errors[0]);

            return Ok(response.Message);
        }

    }
}

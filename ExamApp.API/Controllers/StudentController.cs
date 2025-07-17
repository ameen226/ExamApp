using ExamApp.Application.Dtos.Student;
using ExamApp.Application.Interfaces.Services;
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
    }
}

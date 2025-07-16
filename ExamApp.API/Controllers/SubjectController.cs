using ExamApp.Application.Dtos.Subject;
using ExamApp.Application.Interfaces.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ExamApp.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SubjectController : ControllerBase
    {
        private readonly ISubjectService _subjectService;

        public SubjectController(ISubjectService subjectService)
        {
            _subjectService = subjectService;
        }


        [HttpGet("{id}")]
        public async Task<IActionResult> GetSubject(int id)
        {
            var response = await _subjectService.GetSubjectByIdAsync(id);

            return Ok(response.Data);
        }

        [HttpGet]
        public async Task<IActionResult> GetAllSubjects()
        {
            var response = await _subjectService.GetAllSubjectsAsync();
            return Ok(response.Data);
        }

        [HttpPost]
        public async Task<IActionResult> CreateSubject([FromBody] CreateSubjectDto dto)
        {
            var response = await _subjectService.CreateSubjectAsync(dto);

            if (response.Success)
                return Created();

            return BadRequest(response.Errors[0]);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateSubject(int id, [FromBody] UpdateSubjectDto dto)
        {
            if (id != dto.Id)
                return BadRequest();

            var response = await _subjectService.UpdateSubjectAsync(dto);

            if (response.Success)
                return Ok();

            return BadRequest(response.Errors[0]);
        }
    }
}

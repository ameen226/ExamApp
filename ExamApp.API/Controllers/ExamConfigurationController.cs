using ExamApp.Application.Dtos.ExamConfiguration;
using ExamApp.Application.Interfaces.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ExamApp.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ExamConfigurationController : ControllerBase
    {
        private readonly IExamConfigurationService _examConfigurationService;

        public ExamConfigurationController(IExamConfigurationService examConfigurationService)
        {
            _examConfigurationService = examConfigurationService;
        }

        [Authorize(Roles = "admin")]
        [HttpPost("/api/subject/{subjectId}/exam-configuration")]
        public async Task<IActionResult> AddExamConfiguration(int subjectId, 
            [FromBody] CreateExamConfigurationDto dto)
        {
            if (dto == null)
            {
                return BadRequest();
            }

            var response = await _examConfigurationService.CreateExamConfigurationAsync(subjectId, dto);

            if (!response.Success)
                return BadRequest(response.Message);

            return Ok();
        }

    }
}

using ExamApp.Application.Dtos.Question;
using ExamApp.Application.Interfaces.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ExamApp.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class QuestionController : ControllerBase
    {
        private readonly IQuestionService _questionService;

        public QuestionController(IQuestionService questionService)
        {
            _questionService = questionService;
        }


        [HttpPost]
        [Authorize(Roles = "admin")]

        public async Task<IActionResult> CreateQeustion([FromBody] CreateQuestionDto dto)
        {
            if (dto == null)
                return BadRequest();

            var response = await _questionService.CreateQuestionAsync(dto);

            if (!response.Success)
                return BadRequest(response.Errors[0]);

            return Ok(response);
        }

    }
}

using ExamApp.Application.Interfaces.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ExamApp.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ExamRecordController : ControllerBase
    {
        private readonly IExamRecordService _examRecordService;

        public ExamRecordController(IExamRecordService examRecordService)
        {
            _examRecordService = examRecordService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllExamRecords()
        {
            var response = await _examRecordService.GetAllExamRecords();

            return Ok(response.Data);
        }

        [HttpGet("/api/student/{studentId}/examrecords")]
        public async Task<IActionResult> GetStudentExamRecords(string studentId)
        {
            var response = await _examRecordService.GetStudentExamRecord(studentId);

            if (response.Success != true)
                return BadRequest(response.Errors[0]);

            return Ok(response.Data);
        }


    }
}

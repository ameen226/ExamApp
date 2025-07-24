using ExamApp.Application.Interfaces.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ExamApp.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DashBoardController : ControllerBase
    {
        private readonly IDashBoardService _dashBoardService;

        public DashBoardController(IDashBoardService dashboardService)
        {
            _dashBoardService = dashboardService;
        }

        [Authorize(Roles = "admin")]
        [HttpGet("/api/admin/dashboard")]
        public async Task<IActionResult> GetDashBoardStates()
        {
            var response = await _dashBoardService.GetDashBoardStatesAsync();

            if (!response.Success)
                return BadRequest(response.Errors);

            return Ok(response.Data);
        }

    }
}

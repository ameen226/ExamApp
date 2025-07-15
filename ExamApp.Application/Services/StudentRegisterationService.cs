using ExamApp.Application.Dtos;
using ExamApp.Application.Dtos.Auth;
using ExamApp.Application.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamApp.Application.Services
{
    public class StudentRegisterationService : IStudentRegisterationService
    {
        private readonly IAuthService _authService;
        private readonly IStudentService _studentService;

        public StudentRegisterationService(IAuthService authService, IStudentService studentService)
        {
            _authService = authService;
            _studentService = studentService;
        }

        public async Task<AuthResponseDto> RegisterStudentAsync(RegisterDto dto)
        {
            var response = await _authService.RegisterAsync(dto);

            if (!response.Success)
                return response;

            CreateStudentDto student = new CreateStudentDto()
            {
                Id = response.Id,
                FirstName = dto.FirstName,
                LastName = dto.LastName,
                Email = response.Email,
            };

            await _studentService.AddStudentAsync(student);

            return response;
        }
    }
}

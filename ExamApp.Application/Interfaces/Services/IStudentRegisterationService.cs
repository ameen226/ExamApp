using ExamApp.Application.Dtos.Auth;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamApp.Application.Interfaces.Services
{
    public interface IStudentRegisterationService
    {
        Task<AuthResponseDto> RegisterStudentAsync(RegisterDto dto);
    }
}

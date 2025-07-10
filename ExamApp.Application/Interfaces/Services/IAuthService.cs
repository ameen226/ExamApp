using ExamApp.Application.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamApp.Application.Interfaces.Services
{
    public interface IAuthService
    {
        Task<AuthResponse> RegisterAync(RegisterRequest req);
        Task<AuthResponse> LoginAsync(LoginRequest req);
    }
}

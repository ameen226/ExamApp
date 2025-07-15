using ExamApp.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamApp.Application.Dtos.Auth
{
    public class AuthResponseDto
    {
        public string Id { get; set; }
        public bool Success { get; set; }
        public string Token { get; set; }
        public string Email { get; set; }
        public string Role { get; set; }
        public List<string> Errors { get; set; }
    }
}

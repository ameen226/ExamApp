using ExamApp.Application.Dtos;
using ExamApp.Application.Dtos.Auth;
using ExamApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamApp.Application.Interfaces.Services
{
    public interface IStudentService
    {
        Task<StudentDto> GetStudentByIdAsyn(string studentId);
        Task<IEnumerable<StudentDto>> GetAllStudentsAsyn();
        Task DectivateStudentAsync(string studentId);
        Task ActivateStudentAsync(string studentId);
        Task AddStudentAsync(CreateStudentDto dto);
    }
}

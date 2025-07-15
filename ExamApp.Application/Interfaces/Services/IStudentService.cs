using ExamApp.Application.Dtos.Auth;
using ExamApp.Application.Dtos.Student;
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
        Task<bool> DectivateStudentAsync(string studentId);
        Task<bool> ActivateStudentAsync(string studentId);
        Task<bool> AddStudentAsync(CreateStudentDto dto);
    }
}

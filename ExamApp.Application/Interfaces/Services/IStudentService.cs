using ExamApp.Application.Common.Models;
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
        Task<Response<StudentDto>> GetStudentByIdAsyn(string studentId);
        Task<Response<IEnumerable<StudentDto>>> GetAllStudentsAsyn();
        Task<Response<bool>> DectivateStudentAsync(string studentId);
        Task<Response<bool>> ActivateStudentAsync(string studentId);
        Task AddStudentAsync(CreateStudentDto dto);
    }
}

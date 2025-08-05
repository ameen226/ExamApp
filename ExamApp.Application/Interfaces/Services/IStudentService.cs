using ExamApp.Application.Common.Models;
using ExamApp.Application.Dtos.Auth;
using ExamApp.Application.Dtos.Student;
using ExamApp.Application.Dtos.Subject;
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
        Task<Response<PagedResult<StudentDto>>> GetAllStudentsAsync(PaginationParameters pagination);
        Task<Response<object>> UpdateStudentStatusAsync(string studentId, bool enabled);
        Task AddStudentAsync(CreateStudentDto dto);
        Task<Response<IEnumerable<SubjectDto>>> GetAllStudentSubjectsAsync(string studentId);
        Task<Response<IEnumerable<SubjectDto>>> GetAllStudentUnAttempedSubjectsAsync(string studentId);
        Task<Response<object>> AddStudentSubjectAsync(string studentId, int subjectId);
    }
}

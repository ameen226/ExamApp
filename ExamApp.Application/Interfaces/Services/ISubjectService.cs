using ExamApp.Application.Common.Models;
using ExamApp.Application.Dtos.ExamConfiguration;
using ExamApp.Application.Dtos.Subject;
using ExamApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamApp.Application.Interfaces.Services
{
    public interface ISubjectService
    {
        Task<Response<IEnumerable<SubjectDto>>> GetAllSubjectsAsync();
        Task<Response<SubjectDto?>> GetSubjectByIdAsync(int subjectId);
        Task<Response<object>> UpdateSubjectAsync(UpdateSubjectDto dto);
        Task<Response<object>> CreateSubjectAsync(CreateSubjectDto dto);
    }
}

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
        Task<IEnumerable<SubjectDto>> GetAllSubjectsAsync();
        Task<SubjectDto> GetSubjectByIdAsync(int subjectId);
        Task<ExamConfigurationDto> GetSubjectExamConfigurationAsync(int subjectId);
        Task<bool> CreateSubjectExamConfigurationAsync(CreateExamConfigurationDto createDto);
        Task<bool> UpdateSubjectAsync(UpdateSubjectDto dto);
    }
}

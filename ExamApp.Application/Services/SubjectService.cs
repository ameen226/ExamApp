using ExamApp.Application.Dtos.ExamConfiguration;
using ExamApp.Application.Dtos.Subject;
using ExamApp.Application.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamApp.Application.Services
{
    public class SubjectService : ISubjectService
    {
        public Task<bool> CreateSubjectExamConfigurationAsync(CreateExamConfigurationDto createDto)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<SubjectDto>> GetAllSubjectsAsync()
        {
            throw new NotImplementedException();
        }

        public Task<SubjectDto> GetSubjectByIdAsync(int subjectId)
        {
            throw new NotImplementedException();
        }

        public Task<ExamConfigurationDto> GetSubjectExamConfigurationAsync(int subjectId)
        {
            throw new NotImplementedException();
        }

        public Task<bool> UpdateSubjectAsync(UpdateSubjectDto dto)
        {
            throw new NotImplementedException();
        }
    }
}

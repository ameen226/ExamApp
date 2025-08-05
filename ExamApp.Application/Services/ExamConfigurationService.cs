using ExamApp.Application.Common.Models;
using ExamApp.Application.Dtos.ExamConfiguration;
using ExamApp.Application.Interfaces.Services;
using ExamApp.Domain.Entities;
using ExamApp.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamApp.Application.Services
{
    public class ExamConfigurationService : IExamConfigurationService
    {
        private readonly IUnitOfWork _unitOfWork;

        public ExamConfigurationService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Response<object>> CreateExamConfigurationAsync(int subjectId, CreateExamConfigurationDto dto)
        {
            var response = new Response<object>();

            var exists = await _unitOfWork.ExamConfigurations.ExamConfigurationExists(subjectId);

            if (exists)
            {
                response.Success = false;
                response.Errors = ["Exam Configuration already exists"];
                return response;
            }

            var questionExistedCount = await _unitOfWork.Questions
                .GetQuestionCountBySubjectIdAsync(subjectId);

            if (questionExistedCount < dto.NumberOfQuestions)
            {
                response.Success = false;
                response.Errors = ["Subject questions count is not sufficient for request"];
                return response;
            }

            ExamConfiguration model = new ExamConfiguration()
            {
                NumberOfQuestions = dto.NumberOfQuestions,
                Duration = dto.Duration,
                SubjectId = subjectId
            };

            await _unitOfWork.ExamConfigurations.AddAsync(model);
            int res = await _unitOfWork.SaveChangesAsync();

            if (res <= 0)
            {
                response.Success = false;
                response.Errors = ["Failed to add exam configuration"];
                return response;
            }

            response.Success = true;
            return response;
        }
    }
}

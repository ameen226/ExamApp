using ExamApp.Application.Dtos;
using ExamApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamApp.Application.Interfaces.Services
{
    public interface IQuestionService
    {
        Task CreateQuestionForSubjectAsync(CreateQuestionDto createDto);
        Task<IEnumerable<QuestionDto>> GetSubjectQuestions(int subjectId);

    }
}

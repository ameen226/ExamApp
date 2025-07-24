using ExamApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamApp.Domain.Interfaces.Repositories
{
    public interface IExamRepository : IGenericRepository<Exam>
    {
        Task<Exam> GetByIdWithExamQuestionAndQuestionAndAnswers(int id);
        Task<IEnumerable<Exam>> GetExamHistoriesWithStudentAndSubjectAsync();
        Task<IEnumerable<Exam>> GetExamHistoryForStudentWithSubjectAsync(string studentId);
        Task<bool> ExamExistsAsync(int subjectId);
    }
}

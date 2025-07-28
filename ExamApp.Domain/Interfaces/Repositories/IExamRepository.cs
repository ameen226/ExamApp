using ExamApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ExamApp.Domain.Interfaces.Repositories
{
    public interface IExamRepository : IGenericRepository<Exam>
    {
        Task<Exam> GetByIdWithExamQuestionAndQuestionAndAnswers(int id);
        Task<IEnumerable<Exam>> GetExamHistoriesWithStudentAndSubjectAsync();
        Task<IEnumerable<Exam>> GetExamHistoryForStudentWithSubjectAsync(string studentId);
        Task<bool> ExamExistsAsync(int subjectId, string studentId);
        Task<int> ExamCountAsync(Expression<Func<Exam,bool>>? predicate = null);
    }
}

using ExamApp.Domain.Entities;
using ExamApp.Domain.Enums;
using ExamApp.Domain.Interfaces.Repositories;
using ExamApp.Infrastructure.Persistence.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ExamApp.Infrastructure.Persistence.Repositories
{
    public class ExamRepository : GenericRepository<Exam>, IExamRepository
    {
        public ExamRepository(ApplicationDbContext db) : base(db)
        {

        }

        public async Task<bool> ExamExistsAsync(int subjectId)
        {
            return await _db.Exams.AnyAsync(e => e.SubjectId == subjectId);
        }

        public async Task<IEnumerable<Exam>> GetExamHistoryForStudentWithSubjectAsync(string studentId)
        {
            return await _db.Exams.Where(e => e.StudentId == studentId && e.Status == ExamStatus.Submitted)
                .Include(e => e.Subject).ToListAsync();
        }

        public async Task<IEnumerable<Exam>> GetExamHistoriesWithStudentAndSubjectAsync()
        {
            return await _db.Exams.Where(e => e.Status == ExamStatus.Submitted).Include(e => e.Student)
                .Include(e => e.Subject).ToListAsync();
        }

        public async Task<Exam> GetByIdWithExamQuestionAndQuestionAndAnswers(int id)
        {
            return await _db.Exams.Include(e => e.ExamQuestions)
                .ThenInclude(ex => ex.Question)
                .ThenInclude(ex => ex.Answers).FirstOrDefaultAsync(e => e.Id == id);
        }

        public async Task<int> ExamCountAsync(Expression<Func<Exam, bool>>? predicate = null)
        {
            if (predicate != null)
                return await _db.Exams.CountAsync(predicate);

            return await _db.Exams.CountAsync();
        }
    }
}

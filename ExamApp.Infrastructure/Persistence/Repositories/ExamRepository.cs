using ExamApp.Domain.Entities;
using ExamApp.Domain.Interfaces.Repositories;
using ExamApp.Infrastructure.Persistence.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamApp.Infrastructure.Persistence.Repositories
{
    public class ExamRepository : GenericRepository<Exam>, IExamRepository
    {
        public ExamRepository(ApplicationDbContext db) : base(db)
        {

        }

        public async Task<Exam> GetByIdWithExamQuestionAndQuestionAndAnswers(int id)
        {
            return await _db.Exams.Include(e => e.ExamQuestions)
                .ThenInclude(ex => ex.Question)
                .ThenInclude(ex => ex.Answers).FirstOrDefaultAsync(e => e.Id == id);
        }
    }
}

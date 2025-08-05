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
    public class QuestionRepository : GenericRepository<Question>, IQuestionRepository
    {
        public QuestionRepository(ApplicationDbContext db) : base(db)
        {

        }

        public async Task<int> GetQuestionCountBySubjectIdAsync(int subjectId)
        {
            return await _db.Questions.CountAsync(q => q.SubjectId == subjectId);
        }
    }
}

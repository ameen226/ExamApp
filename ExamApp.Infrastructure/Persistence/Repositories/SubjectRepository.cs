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
    public class SubjectRepository : GenericRepository<Subject>, ISubjectRepository
    {
        public SubjectRepository(ApplicationDbContext db) : base(db)
        {

        }

        public async Task<Subject> GetByIdWithQuestionsAsync(int id)
        {
            return await _db.Subjects.Include(s => s.Questions).FirstOrDefaultAsync(s => s.Id == id);
        }

        public async Task<bool> SubjectExistsByName(string name)
        {
            return await _db.Subjects.AnyAsync(s => s.Name.ToLower() == name.ToLower());
        }
    }
}

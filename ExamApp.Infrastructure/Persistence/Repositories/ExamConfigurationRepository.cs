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
    public class ExamConfigurationRepository : GenericRepository<ExamConfiguration>, IExamConfigurationRepository
    {
        public ExamConfigurationRepository(ApplicationDbContext db) : base(db)
        {

        }

        public async Task<bool> ExamConfigurationExists(int subjectId)
        {
            return await _db.ExamConfigurations.AnyAsync(ec => ec.SubjectId == subjectId);
        }

        public async Task<ExamConfiguration> GetBySubjectIdAsync(int subjectId)
        {
            return await _db.ExamConfigurations.FirstOrDefaultAsync(ex => ex.SubjectId == subjectId);
        }
    }
}

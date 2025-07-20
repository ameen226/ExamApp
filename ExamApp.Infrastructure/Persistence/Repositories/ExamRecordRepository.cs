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
    public class ExamRecordRepository : GenericRepository<ExamRecord>, IExamRecordRepository
    {
        public ExamRecordRepository(ApplicationDbContext db) : base(db)
        {

        }

        public async Task<IEnumerable<ExamRecord>> GetAllStudentExamRecordsAsync(string studentId)
        {
            return await _db.ExamRecords.Where(er => er.StudentId == studentId).ToListAsync();
        }
    }
}

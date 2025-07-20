using ExamApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamApp.Domain.Interfaces.Repositories
{
    public interface IExamRecordRepository : IGenericRepository<ExamRecord>
    {
        Task<IEnumerable<ExamRecord>> GetAllStudentExamRecordsAsync(string studentId);
    }
}

using ExamApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamApp.Domain.Interfaces.Repositories
{
    public interface IExamRecordRepository
    {
        Task<ExamRecord> GetByIdAsync(int id);
        Task<IEnumerable<ExamRecord>> GetAllAsync();
        Task AddAsync(ExamRecord record);
        void Update(ExamRecord record);
        void Remove(ExamRecord record);
    }
}

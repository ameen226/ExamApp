using ExamApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamApp.Domain.Interfaces.Repositories
{
    public interface IExamConfigurationRepository
    {
        Task<ExamConfiguration> GetByIdAsync(int id);
        Task<IEnumerable<ExamConfiguration>> GetAllAsync();
        Task AddAsync(ExamConfiguration examConfiguration);
        void Update(ExamConfiguration examConfiguration);
        void Delete(ExamConfiguration examConfiguration);
    }
}

using ExamApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamApp.Domain.Interfaces.Repositories
{
    public interface ISubjectRepository
    {
        Task<Subject?> GetByIdAsync(int id);
        Task<IEnumerable<Subject>> GetAllAsync();
        Task AddAsync(Subject subject);
        void Remove(Subject subject);
        void Update(Subject subject);
    }
}

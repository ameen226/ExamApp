using ExamApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamApp.Domain.Interfaces.Repositories
{
    public interface IAnswerRepostiory
    {
        Task<Answer> GetByIdAsync(int id);
        Task<IEnumerable<Answer>> GetAllAsync();
        Task AddAsync(Answer answer);
        void Update(Answer answer);
        void Remove(Answer answer);
    }
}

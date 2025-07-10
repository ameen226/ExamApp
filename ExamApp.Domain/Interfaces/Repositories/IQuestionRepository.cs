using ExamApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamApp.Domain.Interfaces.Repositories
{
    public interface IQuestionRepository
    {
        Task<Question> GetByIdAsync(int id);
        Task<IEnumerable<Question>> GetAllAsync();
        Task AddAsync(Question question);
        void Update(Question question);
        void Remove(Question question);

    }
}

using ExamApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace ExamApp.Domain.Interfaces.Repositories
{
    public interface IStudentRepository : IGenericRepository<Student>
    {
        Task<IEnumerable<Subject>> GetStudentSubjectsAsync(string studentId);
        Task<IEnumerable<Subject>> GetStudentUnAttempedSubjectsAsync(string studentId);
        Task<bool> StudentExists(string studentId);
        Task<int> StudentCountAsync(Expression<Func<Student, bool>>? predicate = null);
        Task AddSubjectToStudentAsync(string studentId, int subjectId);
    }
}

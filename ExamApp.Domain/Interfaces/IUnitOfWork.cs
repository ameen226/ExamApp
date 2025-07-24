using ExamApp.Domain.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamApp.Domain.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        IAnswerRepostiory Answers { get; }
        IExamConfigurationRepository ExamConfigurations { get; }
        IQuestionRepository Questions { get; }
        IStudentRepository Students { get; }
        ISubjectRepository Subjects { get; }
        IExamRepository Exams { get; }
        Task<int> SaveChangesAsync();
    }
}

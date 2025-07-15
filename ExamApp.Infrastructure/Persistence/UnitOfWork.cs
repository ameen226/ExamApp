using ExamApp.Domain.Interfaces;
using ExamApp.Domain.Interfaces.Repositories;
using ExamApp.Infrastructure.Persistence.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamApp.Infrastructure.Persistence
{
    public class UnitOfWork : IUnitOfWork
    {
        public ApplicationDbContext _db { get; set; }
        public IAnswerRepostiory Answers { get; }

        public IExamConfigurationRepository ExamConfigurations { get; }

        public IExamRecordRepository ExamRecords { get; }

        public IQuestionRepository Questions { get; }

        public IStudentRepository Students { get; }

        public ISubjectRepository Subjects { get; }

        public UnitOfWork(ApplicationDbContext db, IStudentRepository studentRepository)
        {
            Students = studentRepository;
            _db = db;
        }

        public void Dispose()
        {
            _db.Dispose();
        }

        public async Task<int> SaveChangesAsync()
        {
            return await _db.SaveChangesAsync();
        }
    }
}

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
        public IQuestionRepository Questions { get; }
        public IStudentRepository Students { get; }
        public ISubjectRepository Subjects { get; }
        public IExamRepository Exams { get; }

        public UnitOfWork(ApplicationDbContext db, IStudentRepository studentRepository,
            ISubjectRepository subjectRepository, IAnswerRepostiory answerRepostiory, 
            IQuestionRepository questionRepository, IExamConfigurationRepository examConfigurationRepository,
            IExamRepository examRepository)
        {
            Answers = answerRepostiory;
            Questions = questionRepository;
            ExamConfigurations = examConfigurationRepository;
            Students = studentRepository;
            Subjects = subjectRepository;
            Exams = examRepository;
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

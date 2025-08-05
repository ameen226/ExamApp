using ExamApp.Application.Dtos;
using ExamApp.Domain.Entities;
using ExamApp.Domain.Interfaces.Repositories;
using ExamApp.Infrastructure.Persistence.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ExamApp.Infrastructure.Persistence.Repositories
{
    public class StudentRepository : GenericRepository<Student>, IStudentRepository
    {
        public StudentRepository(ApplicationDbContext db) : base(db)
        {

        }

        public async Task AddSubjectToStudentAsync(string studentId, int subjectId)
        {
            await _db.StudentSubjects.AddAsync(new StudentSubject
            {
                StudentId = studentId,
                SubjectId = subjectId
            });
        }

        public async Task<IEnumerable<Subject>> GetStudentSubjectsAsync(string studentId)
        {
            var subjects = await _db.StudentSubjects.Where(ss => ss.StudentId == studentId)
                                                .Include(ss => ss.Subject)
                                                .Select(ss => ss.Subject)
                                                .ToListAsync();
            return subjects;
        }

        public async Task<IEnumerable<Subject>> GetStudentUnAttempedSubjectsAsync(string studentId)
        {
            var subjects = await _db.StudentSubjects.Where(ss => ss.StudentId == studentId 
                                                           && ss.HasAttempedExam == false)
                                                .Include(ss => ss.Subject)
                                                .Select(ss => ss.Subject)
                                                .ToListAsync();
            return subjects;
        }

        public async Task<int> StudentCountAsync(Expression<Func<Student, bool>>? predicate = null)
        {
            if (predicate != null)
                return await _db.Students.CountAsync(predicate);

            return await _db.Students.CountAsync();

        }

        public async Task<bool> StudentExists(string studentId)
        {
            return await _db.Students.AnyAsync(s => s.Id == studentId);
        }
    }
}

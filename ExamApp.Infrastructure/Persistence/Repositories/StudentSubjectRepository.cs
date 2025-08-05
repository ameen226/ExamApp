using ExamApp.Domain.Entities;
using ExamApp.Domain.Interfaces.Repositories;
using ExamApp.Infrastructure.Persistence.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamApp.Infrastructure.Persistence.Repositories
{
    public class StudentSubjectRepository : GenericRepository<StudentSubject>, IStudentSubjectRepository
    {

        public StudentSubjectRepository(ApplicationDbContext db): base(db)
        {

        }

        public async Task<StudentSubject?> GetStudentSubjectAsync(string studentId, int subjectId)
        {
            return await _db.StudentSubjects.FirstOrDefaultAsync(ss => ss.StudentId == studentId
                                                          && ss.SubjectId == subjectId);
        }
    }
}

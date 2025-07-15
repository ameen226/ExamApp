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
    public class SubjectRepository : ISubjectRepository
    {
        private readonly ApplicationDbContext _db;

        public SubjectRepository(ApplicationDbContext db)
        {
            _db = db;
        }

        public async Task<Subject> GetByIdAsync(int id)
        {
            return await _db.Subjects.FindAsync(id);
        }

        public async Task<IEnumerable<Subject>> GetAllAsync()
        {
            return await _db.Subjects.ToListAsync();
        }

        public async Task AddAsync(Subject subject)
        {
            await _db.Subjects.AddAsync(subject);
        }

        public void Remove(Subject subject)
        {
            _db.Subjects.Remove(subject);
        }

        public void Update(Subject subject)
        {
            _db.Subjects.Update(subject);
        }
    }
}

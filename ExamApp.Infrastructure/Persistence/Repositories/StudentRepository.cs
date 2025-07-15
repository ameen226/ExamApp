using ExamApp.Application.Dtos;
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
    public class StudentRepository : IStudentRepository
    {
        private readonly ApplicationDbContext _db;

        public StudentRepository(ApplicationDbContext db)
        {
            _db = db;
        }

        public async Task AddAsync(Student student)
        {
            await _db.Students.AddAsync(student);
        }

        public async Task<IEnumerable<Student>> GetAllAsync()
        {
            return await _db.Students.ToListAsync();
        }

        public async Task<Student> GetByIdAsync(string id)
        {
            return await _db.Students.FindAsync(id);
        }

        public void Remove(Student student)
        {
            _db.Students.Remove(student);
        }

        public void Update(Student student)
        {
            _db.Students.Update(student);
        }
    }
}

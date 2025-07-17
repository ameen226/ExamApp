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
    public class StudentRepository : GenericRepository<Student>, IStudentRepository
    {
        public StudentRepository(ApplicationDbContext db) : base(db)
        {

        }
    }
}

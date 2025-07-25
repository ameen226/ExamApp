﻿using ExamApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ExamApp.Domain.Interfaces.Repositories
{
    public interface IStudentRepository : IGenericRepository<Student>
    {
        Task<IEnumerable<Subject>> GetStudentSubjectsAsync(string studentId);
        Task<bool> StudentExists(string studentId);
        Task<int> StudentCountAsync(Expression<Func<Student, bool>>? predicate = null);
    }
}

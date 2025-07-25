﻿using ExamApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamApp.Domain.Interfaces.Repositories
{
    public interface ISubjectRepository : IGenericRepository<Subject>
    {
        Task<bool> SubjectExistsByName(string name);
        Task<Subject> GetByIdWithQuestionsAsync(int id);
    }
}

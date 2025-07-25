﻿using ExamApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamApp.Domain.Interfaces.Repositories
{
    public interface IExamConfigurationRepository : IGenericRepository<ExamConfiguration>
    {
        Task<ExamConfiguration> GetBySubjectIdAsync(int subjectId);
    }
}

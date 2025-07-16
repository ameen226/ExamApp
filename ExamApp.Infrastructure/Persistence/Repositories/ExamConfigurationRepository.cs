using ExamApp.Domain.Entities;
using ExamApp.Domain.Interfaces.Repositories;
using ExamApp.Infrastructure.Persistence.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamApp.Infrastructure.Persistence.Repositories
{
    public class ExamConfigurationRepository : GenericRepository<ExamConfiguration>, IExamConfigurationRepository
    {
        public ExamConfigurationRepository(ApplicationDbContext db) : base(db)
        {

        }
    }
}

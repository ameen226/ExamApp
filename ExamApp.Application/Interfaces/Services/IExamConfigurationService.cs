using ExamApp.Application.Common.Models;
using ExamApp.Application.Dtos.ExamConfiguration;
using ExamApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace ExamApp.Application.Interfaces.Services
{
    public interface IExamConfigurationService
    {
        Task<Response<object>> CreateExamConfigurationAsync(int subjectId, CreateExamConfigurationDto dto);
        
    }
}

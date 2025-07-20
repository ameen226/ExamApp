using ExamApp.Application.Common.Models;
using ExamApp.Application.Dtos.ExamRecord;
using ExamApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamApp.Application.Interfaces.Services
{
    public interface IExamRecordService
    {
        Task<Response<IEnumerable<ExamRecordDto>>> GetAllExamRecords();
        Task<Response<IEnumerable<ExamRecordDto>>> GetStudentExamRecord(string studentId);
    }
}

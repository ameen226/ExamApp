using ExamApp.Application.Common.Models;
using ExamApp.Application.Dtos.Exam;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamApp.Application.Interfaces.Services
{
    public interface IExamService
    {
        Task<Response<ExamDto>> RequestExamAsync(CreateExamDto dto, string studentId);
        Task<Response<object>> SubmitExamAsync(int examId, string studentId, SubmitExamDto dto);
        Task<Response<IEnumerable<ExamRecordDto>>> GetStudentExamHistoryAsync(string studentId);
        Task<Response<PagedResult<ExamRecordDto>>> GetExamHistoriesPagedAsync(PaginationParameters pagination);
    }
}

using ExamApp.Application.Common.Models;
using ExamApp.Application.Dtos.DashBoard;
using ExamApp.Application.Interfaces.Services;
using ExamApp.Domain.Enums;
using ExamApp.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamApp.Application.Services
{
    public class DashBoardService : IDashBoardService
    {
        private readonly IUnitOfWork _unitOfWork;

        public DashBoardService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Response<DashBoardDto>> GetDashBoardStatesAsync()
        {
            var response = new Response<DashBoardDto>();

            var studentCount = await _unitOfWork.Students.StudentCountAsync();
            var examCount = await _unitOfWork.Exams.ExamCountAsync(e => e.Status == ExamStatus.Submitted);
            var passedExamCount = await _unitOfWork.Exams.
                ExamCountAsync(e => e.Score >= 70 && e.Status == ExamStatus.Submitted);

            var failedExamCount = examCount - passedExamCount;

            var dashboardDto = new DashBoardDto()
            {
                TotalStudents = studentCount,
                TotalExamsSubmitted = examCount,
                TotalPassedExams = passedExamCount,
                TotalFailedExams = failedExamCount
            };


            response.Success = true;
            response.Data = dashboardDto;

            return response;
        }
    }
}

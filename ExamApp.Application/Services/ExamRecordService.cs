using ExamApp.Application.Common.Models;
using ExamApp.Application.Dtos.ExamRecord;
using ExamApp.Application.Interfaces.Services;
using ExamApp.Domain.Entities;
using ExamApp.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamApp.Application.Services
{
    public class ExamRecordService : IExamRecordService
    {
        private readonly IUnitOfWork _unitOfWork;

        public ExamRecordService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }


        public async Task<Response<IEnumerable<ExamRecordDto>>> GetAllExamRecords()
        {
            var response = new Response<IEnumerable<ExamRecordDto>>();
            var dataList = new List<ExamRecordDto>();

            var examRecordList = await _unitOfWork.ExamRecords.GetAllAsync();

            if (examRecordList == null)
            {
                response.Success = true;
                response.Message = "No records Found";
                return response;
            }


            foreach(var examrec in examRecordList)
            {
                dataList.Add(new ExamRecordDto()
                {
                    Id = examrec.Id,
                    StudentName = examrec.StudentName,
                    SubjectName = examrec.SubjectName,
                    Score = examrec.Score,
                    DateTime = examrec.DateTime
                });
            }

            response.Success = true;
            response.Data = dataList;
            return response;
        }

        
        public async Task<Response<IEnumerable<ExamRecordDto>>> GetStudentExamRecord(string studentId)
        {
            var response = new Response<IEnumerable<ExamRecordDto>>();
            var dataList = new List<ExamRecordDto>();

            if (!await _unitOfWork.Students.StudentExists(studentId))
            {
                response.Success = false;
                response.Errors = ["Student does not exist"];
                return response;
            }


            var examRecordList = await _unitOfWork.ExamRecords.GetAllStudentExamRecordsAsync(studentId);


            if (examRecordList == null)
            {
                response.Success = true;
                response.Message = "No records Found";
                return response;
            }


            foreach (var examrec in examRecordList)
            {
                dataList.Add(new ExamRecordDto()
                {
                    Id = examrec.Id,
                    StudentName = examrec.StudentName,
                    SubjectName = examrec.SubjectName,
                    Score = examrec.Score,
                    DateTime = examrec.DateTime
                });
            }

            response.Success = true;
            response.Data = dataList;
            return response;
        }
    }
}

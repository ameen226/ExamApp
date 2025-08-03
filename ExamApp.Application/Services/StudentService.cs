using ExamApp.Application.Common.Models;
using ExamApp.Application.Dtos.Auth;
using ExamApp.Application.Dtos.Student;
using ExamApp.Application.Dtos.Subject;
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
    public class StudentService : IStudentService
    {
        private readonly IUnitOfWork _unitOfWork;

        public StudentService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task AddStudentAsync(CreateStudentDto dto)
        {
            Student student = new Student()
            {
                Id = dto.Id,
                FirstName = dto.FirstName,
                LastName  = dto.LastName,
                Email = dto.Email,
                Enabled = true
            };

            await _unitOfWork.Students.AddAsync(student);
            await _unitOfWork.SaveChangesAsync();
        }

        public async Task<Response<object>> AddStudentSubjectAsync(string studentId, int subjectId)
        {
            var response = new Response<object>();

            var student = await _unitOfWork.Students.GetByIdAsync(studentId);

            if (student == null)
            {
                response.Success = false;
                response.Errors = ["Student does not exist"];
                return response;
            }

            var subject = await _unitOfWork.Subjects.GetByIdAsync(subjectId);

            if (subject == null)
            {
                response.Success = false;
                response.Errors = ["Subject does not exist"];
                return response;
            }



            student.Subjects.Add(subject);

            _unitOfWork.Students.Update(student);
            var res = await _unitOfWork.SaveChangesAsync();

            if (res <= 0)
            {
                response.Success = false;
                response.Errors = ["adding failed"];
                return response;
            }

            response.Success = true;
            return response;
        }

        public async Task<Response<PagedResult<StudentDto>>> GetAllStudentsAsync(PaginationParameters pagination)
        {
            var response = new Response<PagedResult<StudentDto>>();


            var pagedStudents = await _unitOfWork.Students.GetPagedAsync(
                    pageNumber: pagination.PageNumber,
                    pageSize: pagination.PageSize
                );


            var studentsDto = pagedStudents.Items.Select(s => new StudentDto()
            {
                Id = s.Id,
                FirstName = s.FirstName,
                LastName = s.LastName,
                Email = s.Email,
                Enabled = s.Enabled
            }).ToList();

            var pageResult = new PagedResult<StudentDto>
            {
                TotalCount = pagedStudents.TotalCount,
                Items = studentsDto,
                PageSize = pagedStudents.PageSize,
                PageNumber = pagedStudents.PageNumber
            };

            response.Success = true;
            response.Data = pageResult;

            return response;
        }

        public async Task<Response<IEnumerable<SubjectDto>>> GetAllStudentSubjectsAsync(string studentId)
        {
            var response = new Response<IEnumerable<SubjectDto>>();
            List<SubjectDto> subjectDtos = new List<SubjectDto>();

            var student = await _unitOfWork.Students.GetByIdAsync(studentId);
            if (student == null)
            {
                response.Success = false;
                response.Errors = ["Wrong student id"];
                return response;
            }

            var subjects = await _unitOfWork.Students.GetStudentSubjectsAsync(studentId);

            foreach (var subject in subjects)
            {
                subjectDtos.Add(new SubjectDto()
                {
                    Id = subject.Id,
                    Name = subject.Name
                });
            }


            response.Success = true;
            response.Data = subjectDtos;
            return response;
        }

        public Task<Response<StudentDto>> GetStudentByIdAsyn(string studentId)
        {
            throw new NotImplementedException();
        }

        public async Task<Response<object>> UpdateStudentStatusAsync(string studentId, bool enabled)
        {
            var student = await _unitOfWork.Students.GetByIdAsync(studentId);

            if (student == null)
            {
                return new Response<object>()
                {
                    Success = false,
                    Errors = ["Student does not exist"]
                };
            }

            if (student.Enabled == enabled)
            {
                return new Response<object>()
                {
                    Success = true,
                    Message = "Student already has the desired status."
                };
            }

            student.Enabled = enabled;
            _unitOfWork.Students.Update(student);

            var result = await _unitOfWork.SaveChangesAsync();

            if (result <= 0)
            {
                return new Response<object>()
                {
                    Success = false,
                    Errors = ["Failed to update student status"]
                };
            }

            return new Response<object>()
            {
                Success = true,
            };
        }
    }
}

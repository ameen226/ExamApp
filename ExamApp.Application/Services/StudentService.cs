using ExamApp.Application.Common.Models;
using ExamApp.Application.Dtos.Auth;
using ExamApp.Application.Dtos.Student;
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

        public Task<Response<bool>> ActivateStudentAsync(string studentId)
        {
            throw new NotImplementedException();
        }

        public async Task AddStudentAsync(CreateStudentDto dto)
        {
            Student student = new Student()
            {
                Id = dto.Id,
                FirstName = dto.FirstName,
                LastName  = dto.LastName,
                Email = dto.Email
            };

            await _unitOfWork.Students.AddAsync(student);
            await _unitOfWork.SaveChangesAsync();
        }

        public Task<Response<bool>> DectivateStudentAsync(string studentId)
        {
            throw new NotImplementedException();
        }

        public async Task<Response<IEnumerable<StudentDto>>> GetAllStudentsAsyn()
        {
            var students = (await _unitOfWork.Students.GetAllAsync()).ToList();
            var studentsDto = students.Select(s => new StudentDto()
            {
                Id = s.Id,
                FirstName = s.FirstName,
                LastName = s.LastName,
                Email = s.Email
            });

            return new Response<IEnumerable<StudentDto>>()
            {
                Success = true,
                Data = studentsDto
            };
        }

        public Task<Response<StudentDto>> GetStudentByIdAsyn(string studentId)
        {
            throw new NotImplementedException();
        }

        
    }
}

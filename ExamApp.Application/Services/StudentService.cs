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

        public Task<bool> ActivateStudentAsync(string studentId)
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

        public Task<bool> DectivateStudentAsync(string studentId)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<StudentDto>> GetAllStudentsAsyn()
        {
            throw new NotImplementedException();
        }

        public Task<StudentDto> GetStudentByIdAsyn(string studentId)
        {
            throw new NotImplementedException();
        }

        Task<bool> IStudentService.AddStudentAsync(CreateStudentDto dto)
        {
            throw new NotImplementedException();
        }
    }
}

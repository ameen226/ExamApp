using ExamApp.Application.Common.Models;
using ExamApp.Application.Dtos.ExamConfiguration;
using ExamApp.Application.Dtos.Student;
using ExamApp.Application.Dtos.Subject;
using ExamApp.Application.Interfaces.Services;
using ExamApp.Domain.Entities;
using ExamApp.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace ExamApp.Application.Services
{
    public class SubjectService : ISubjectService
    {
        private readonly IUnitOfWork _unitOfWork;

        public SubjectService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Response<object>> CreateSubjectAsync(CreateSubjectDto dto)
        {
            Subject subject = new Subject()
            {
                Name = dto.Name
            };

            if (await _unitOfWork.Subjects.SubjectExistsByName(dto.Name))
            {
                return new Response<object>()
                {
                    Success = false,
                    Errors = ["Subject name already exists"]
                };
            }

            await _unitOfWork.Subjects.AddAsync(subject);
            var result = await _unitOfWork.SaveChangesAsync();

            if (result <= 0)
            {
                return new Response<object>()
                {
                    Success = false,
                    Errors = ["Failed to add the subject"]
                };
            }

            return new Response<object>()
            {
                Success = true,
            };

        }

        public async Task<Response<IEnumerable<SubjectDto>>> GetAllSubjectsAsync()
        {
            var subjectList = (await _unitOfWork.Subjects.GetAllAsync()).ToList();

            var SubjectDtos = subjectList.Select(s => new SubjectDto
            {
                Id = s.Id,
                Name = s.Name
            });

            return new Response<IEnumerable<SubjectDto>>
            {
                Success = true,
                Data = SubjectDtos
            };
        }

        public async Task<Response<SubjectDto>> GetSubjectByIdAsync(int subjectId)
        {
            var subject = await _unitOfWork.Subjects.GetByIdAsync(subjectId);
            var res = new Response<SubjectDto>();

            if (subject != null)
            {
                res.Success = true;
                res.Data = new SubjectDto()
                {
                    Id = subject.Id,
                    Name = subject.Name
                };
            }
            else
            {
                res.Success = true;
                res.Data = null;
            }

            return res;
                       
        }

        
        public async Task<Response<object>> UpdateSubjectAsync(UpdateSubjectDto dto)
        {
            var subject = await _unitOfWork.Subjects.GetByIdAsync(dto.Id);

            if (subject == null)
            {
                return new Response<object>()
                {
                    Success = false,
                    Errors = ["Subject does not exist"]
                };
            }

            subject.Name = dto.Name;
            _unitOfWork.Subjects.Update(subject);

            var res = await _unitOfWork.SaveChangesAsync();
            if (res <= 0)
            {
                return new Response<object>()
                {
                    Success = false,
                    Errors = [""]
                };
            }

            return new Response<object>()
            {
                Success = true
            };
        }
    }
}

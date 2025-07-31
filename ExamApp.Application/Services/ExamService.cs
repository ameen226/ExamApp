using ExamApp.Application.Common.Models;
using ExamApp.Application.Dtos.Answer;
using ExamApp.Application.Dtos.Exam;
using ExamApp.Application.Dtos.ExamQuestion;
using ExamApp.Application.Interfaces.Services;
using ExamApp.Domain.Entities;
using ExamApp.Domain.Enums;
using ExamApp.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamApp.Application.Services
{
    public class ExamService : IExamService
    {
        private readonly IUnitOfWork _unitOfWork;

        public ExamService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Response<PagedResult<ExamRecordDto>>> GetExamHistoriesPagedAsync(
            PaginationParameters pagination
            )
        {
            var response = new Response<PagedResult<ExamRecordDto>>();
            var examsHistories = await _unitOfWork.Exams.GetPagedAsync(pagination.PageNumber,
                pagination.PageSize,null, e => e.Student, e => e.Subject);

            if (examsHistories == null || !examsHistories.Items.Any())
            {
                response.Success = true;
                response.Message = "No exams found";
                response.Data = new PagedResult<ExamRecordDto>
                {
                    Items = new List<ExamRecordDto>(),
                    PageNumber = pagination.PageNumber,
                    PageSize = pagination.PageSize,
                    TotalCount = 0
                };
                return response;
            }

            List<ExamRecordDto> examRecordDtos = new List<ExamRecordDto>();

            foreach (var exam in examsHistories.Items)
            {
                examRecordDtos.Add(new ExamRecordDto()
                {
                    Id = exam.Id,
                    StudentName = exam.Student.FirstName + " " + exam.Student.LastName,
                    StudentEmail = exam.Student.Email,
                    SubjectName = exam.Subject.Name,
                    StartedAt = exam.StartedAt,
                    SubmitedAt = exam.SubmitedAt,
                    Score = exam.Score
                });
            }

            response.Success = true;
            response.Data = new PagedResult<ExamRecordDto>
            {
                Items = examRecordDtos,
                PageNumber = pagination.PageNumber,
                PageSize = pagination.PageSize,
                TotalCount = examsHistories.TotalCount
            };

            return response;
        }

        public async Task<Response<PagedResult<ExamRecordDto>>> GetStudentExamHistoryPagedAsync(
            PaginationParameters pagination,
            string studentId
            )
        {
            var response = new Response<PagedResult<ExamRecordDto>>();

            var student = await _unitOfWork.Students.GetByIdAsync(studentId);

            if (student == null)
            {
                response.Success = false;
                response.Errors = ["Student does not exist"];
                return response;
            }

            var examHistory = await _unitOfWork.Exams.GetPagedAsync(pagination.PageNumber,
                pagination.PageSize, s => s.StudentId == studentId, e => e.Student, e => e.Subject);
            
            if (examHistory == null || examHistory.Items.Count == 0)
            {
                response.Success = true;
                response.Message = "No exam records yet";
                return response;
            }

            var examRecordDtos = new List<ExamRecordDto>();

            foreach (var exam in examHistory.Items)
            {
                examRecordDtos.Add(new ExamRecordDto()
                {
                    Id = exam.Id,
                    StudentName = student.FirstName + " " + student.LastName,
                    StudentEmail = student.Email,
                    SubmitedAt = exam.SubmitedAt,
                    StartedAt = exam.StartedAt,
                    SubjectName = exam.Subject.Name,
                    Score = exam.Score
                });
            }

            response.Success = true;
            response.Data = new PagedResult<ExamRecordDto>
            {
                Items = examRecordDtos,
                PageNumber = examHistory.PageNumber,
                PageSize = examHistory.PageSize,
                TotalCount = examHistory.TotalCount
            };
            return response;
        }

        public async Task<Response<ExamDto>> RequestExamAsync(CreateExamDto dto, string studentId)
        {
            var response = new Response<ExamDto>();



            if (dto == null || string.IsNullOrEmpty(studentId))
            {
                response.Success = false;
                return response;
            }

            var subject = await _unitOfWork.Subjects.GetByIdWithQuestionsAsync(dto.SubjectId);

            if (subject == null)
            {
                response.Success = false;
                response.Errors = ["Subject does not exist"];
                return response;
            }

            if (await _unitOfWork.Exams.ExamExistsAsync(dto.SubjectId, studentId))
            {
                response.Success = false;
                response.Errors = ["Exam already requested"];
                return response;
            }

            var examConfig = await _unitOfWork.ExamConfigurations.GetBySubjectIdAsync(dto.SubjectId);

            if (examConfig == null)
            {
                response.Success = false;
                response.Errors = ["There is no exam configurations for the reqeusted exam"];
                return response;
            }

            if (subject.Questions == null || subject.Questions.Count == 0 || examConfig.NumberOfQuestions > subject.Questions.Count)
            {
                response.Success = false;
                response.Errors = ["There is not enough questions to create the exam"];
                return response;
            }

            var examQuestions = subject.Questions.OrderBy(q => Guid.NewGuid())
                .Take(examConfig.NumberOfQuestions)
                .Select(q => new ExamQuestion()
            {
                QuestionId = q.Id,
            }).ToList();

            


            Exam exam = new Exam()
            {
                StudentId = studentId,
                SubjectId = dto.SubjectId,
                StartedAt = DateTime.UtcNow,
                Status = ExamStatus.InProgress,
                ExamQuestions = examQuestions
            };

            await _unitOfWork.Exams.AddAsync(exam);
            var res = await _unitOfWork.SaveChangesAsync();

            if (res <= 0)
            {
                response.Success = false;
                response.Errors = ["Failed to create exam"];
                return response;
            }

            exam = await _unitOfWork.Exams.GetByIdWithExamQuestionAndQuestionAndAnswers(exam.Id);

            var examQuestionDtos = new List<ExamQuestionDto>();

            foreach (var eq in exam.ExamQuestions)
            {
                examQuestionDtos.Add(new ExamQuestionDto()
                {
                    Id = eq.Id,
                    QuestionId = eq.QuestionId,
                    Text = eq.Question.Text,
                    Answers = eq.Question.Answers.Select(a => new AnswerDto()
                    {
                        Id = a.Id,
                        Text = a.Text
                    }).ToList()
                });
            }

            ExamDto examDto = new ExamDto()
            {
                Id = exam.Id,
                SubjectName = subject.Name,
                ExamQuestions = examQuestionDtos
            };

            response.Success = true;
            response.Data = examDto;

            return response;

        }

        public async Task<Response<object>> SubmitExamAsync(int examId, string studentId, SubmitExamDto dto)
        {
            Response<object> response = new Response<object>();

            var exam = await _unitOfWork.Exams.GetByIdWithExamQuestionAndQuestionAndAnswers(examId);
            

            if (exam == null)
            {
                response.Success = false;
                response.Errors = ["Exam does not exist"];
                return response;
            }


            if (exam.StudentId != studentId)
            {
                response.Success = false;
                response.Errors = ["You are not assigned to this exam"];
                return response;
            }

            exam.SubmitedAt = DateTime.UtcNow;
            exam.Status = ExamStatus.Submitted;

            decimal correctAnswersCount = 0;
            decimal questionsCount = exam.ExamQuestions.Count;

            foreach (var answer in dto.ExamQeustions)
            {
                var examQuestion = exam.ExamQuestions.FirstOrDefault(ex => ex.QuestionId == answer.QuestionId);
                if (examQuestion == null)
                {
                    response.Success = false;
                    response.Errors = ["Exam question does not exist"];
                    return response;
                }

                if (examQuestion.Question.RightAnswerId == answer.SelectedAnswerId)
                {
                    examQuestion.IsCorrect = true;
                    examQuestion.SelectedAnswerId = answer.SelectedAnswerId;
                    correctAnswersCount++;
                }
            }

            exam.Score = (correctAnswersCount / questionsCount) * 100;

            _unitOfWork.Exams.Update(exam);
            int res = await _unitOfWork.SaveChangesAsync();

            if (res <= 0)
            {
                response.Success = false;
                response.Errors = ["Failed to submit the exam"];
                return response;
            }

            response.Success = true;
            return response;
        }
    }
}

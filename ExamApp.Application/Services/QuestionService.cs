using ExamApp.Application.Common.Models;
using ExamApp.Application.Dtos.Answer;
using ExamApp.Application.Dtos.Question;
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
    public class QuestionService : IQuestionService
    {
        private readonly IUnitOfWork _unitOfWork;

        public QuestionService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Response<object>> CreateQuestionAsync(CreateQuestionDto createDto)
        {
            var response = new Response<object>();

            var subject = await _unitOfWork.Subjects.GetByIdAsync(createDto.SubjectId);

            if (subject == null)
            {
                response.Success = false;
                response.Errors = ["Subject does not exist"];
                return response;
            }

            var question = new Question()
            {
                Text = createDto.Text,
                SubjectId = createDto.SubjectId,
                Difficulty = createDto.Difficulty
            };

            if (createDto.CorrectAnswerIndex < 0 || createDto.CorrectAnswerIndex > createDto.AnswersList.Count())
            {
                response.Success = false;
                response.Errors = ["Ivalid correct answer index"];
                return response;
            }

            if (createDto.AnswersList == null)
            {
                response.Success = false;
                response.Errors = ["No Answers provided"];
            }

            foreach (var answer in createDto.AnswersList)
            {
                question.Answers.Add(new Answer()
                {
                    Text = answer.Text,
                });
            }

            await _unitOfWork.Questions.AddAsync(question);
            var result = await _unitOfWork.SaveChangesAsync();

            if (result <= 0)
            {
                response.Success = false;
                response.Errors = ["Failed to add Qeustion"];
                return response;
            }


            var correctAnswerId = question.Answers[createDto.CorrectAnswerIndex];
            question.RightAnswerId = correctAnswerId.Id;

            result = await _unitOfWork.SaveChangesAsync();
            if (result <= 0)
            {
                response.Success = false;
                response.Errors = ["Failed to set the correct answer"];
                return response;
            }

            response.Success = true;
            response.Message = "Question added successfully";

            return response;
        }

        public Task<IEnumerable<QuestionDto>> GetSubjectQuestions(int subjectId)
        {
            throw new NotImplementedException();
        }
    }
}

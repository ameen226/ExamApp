﻿using ExamApp.Application.Common.Models;
using ExamApp.Application.Dtos.Question;
using ExamApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamApp.Application.Interfaces.Services
{
    public interface IQuestionService
    {
        Task<Response<object>> CreateQuestionAsync(CreateQuestionDto createDto);
        Task<IEnumerable<QuestionDto>> GetSubjectQuestions(int subjectId);

    }
}

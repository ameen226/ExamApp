using ExamApp.Application.Dtos.Answer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamApp.Application.Dtos.ExamQuestion
{
    public class ExamQuestionDto
    {
        public int Id { get; set; }
        public int QuestionId { get; set; }
        public string Text { get; set; }
        public List<AnswerDto> Answers { get; set; }
    }
}

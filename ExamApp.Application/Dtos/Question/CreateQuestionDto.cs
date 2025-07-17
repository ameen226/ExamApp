using ExamApp.Application.Dtos.Answer;
using ExamApp.Domain.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamApp.Application.Dtos.Question
{
    public class CreateQuestionDto
    {
        [Required]
        public string Text { get; set; }
        public Difficulty Difficulty { get; set; }
        public int CorrectAnswerIndex { get; set; }
        public int SubjectId { get; set; }
        public IEnumerable<CreateAnswerDto> AnswersList { get; set; }
    }
}

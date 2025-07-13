using ExamApp.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamApp.Application.Dtos
{
    public class QuestionDto
    {
        public string Text { get; set; }
        public Difficulty Difficulty { get; set; }
        public int RightAnswerId { get; set; }
        public IEnumerable<AnswerDto> Answers { get; set; }
        public int SubjectId { get; set; }

    }
}

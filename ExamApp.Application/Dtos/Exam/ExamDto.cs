using ExamApp.Application.Dtos.ExamQuestion;
using ExamApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamApp.Application.Dtos.Exam
{
    public class ExamDto
    {
        public int Id { get; set; }
        public string SubjectName { get; set; }
        public ICollection<ExamQuestionDto> ExamQuestions { get; set; }
        public DateTime StartedAt { get; set; }
        public TimeSpan Duration { get; set; }
    }
}

using ExamApp.Application.Dtos.ExamQuestion;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamApp.Application.Dtos.Exam
{
    public class SubmitExamDto
    {
        public int Id { get; set; }
        public ICollection<SubmitExamQuestionDto> ExamQeustions { get; set; }
    }
}

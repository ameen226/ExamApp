using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamApp.Application.Dtos.ExamQuestion
{
    public class SubmitExamQuestionDto
    {
        public int Id { get; set; }
        public int QuestionId { get; set; }
        public int SelectedAnswerId { get; set; }
    }
}

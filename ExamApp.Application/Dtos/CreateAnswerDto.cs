using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamApp.Application.Dtos
{
    public class CreateAnswerDto
    {
        public string Text { get; set; }
        public int QuestionId { get; set; }
    }
}

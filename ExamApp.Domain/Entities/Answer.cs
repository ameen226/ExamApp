using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamApp.Domain.Entities
{
    public class Answer
    {
        public int Id { get; set; }
        public string Text { get; set; } = string.Empty;
        public int QuestionId { get; set; }
        public Question Question { get; set; }
        public bool IsChosen { get; set; }
    }
}

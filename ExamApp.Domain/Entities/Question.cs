using ExamApp.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamApp.Domain.Entities
{
    public class Question
    {
        public int Id { get; set; }
        public string Text { get; set; } = string.Empty;
        public Difficulty Difficulty { get; set; }
        public int? RightAnswerId { get; set; }
        public Answer? RightAnswer { get; set; }
        public List<Answer> Answers { get; set; } = new List<Answer>();
        public int SubjectId { get; set; }
        public Subject? Subject { get; set; }
    }
}

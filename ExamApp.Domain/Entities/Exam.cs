using ExamApp.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamApp.Domain.Entities
{
    public class Exam
    {
        public int Id { get; set; }

        public string StudentId { get; set; }
        public Student Student { get; set; }

        public int SubjectId { get; set; }
        public Subject Subject { get; set; }

        public DateTime StartedAt { get; set; } = DateTime.UtcNow;
        public DateTime SubmitedAt { get; set; }

        public ExamStatus Status { get; set; } = ExamStatus.InProgress;

        public decimal Score { get; set; }

        public ICollection<ExamQuestion> ExamQuestions { get; set; } = new List<ExamQuestion>();

    }
}

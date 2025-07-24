using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamApp.Application.Dtos.Exam
{
    public class ExamRecordDto
    {
        public int Id { get; set; }
        public string StudentName { get; set; }
        public string StudentEmail { get; set; }
        public string SubjectName { get; set; }
        public DateTime StartedAt { get; set; }
        public DateTime SubmitedAt { get; set; }
        public decimal Score { get; set; }
    }
}

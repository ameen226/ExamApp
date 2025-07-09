using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamApp.Domain.Entities
{
    public class ExamConfiguration
    {
        public int Id { get; set; }
        public TimeSpan Duration { get; set; }
        public int NumberOfQuestions { get; set; }
        public int SubjectId { get; set; }
        public Subject Subject { get; set; }

    }
}

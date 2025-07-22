using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamApp.Application.Dtos.ExamConfiguration
{
    public class CreateExamConfigurationDto
    {
        public TimeSpan Duration { get; set; }
        public int NumberOfQuestions { get; set; }
    }
}

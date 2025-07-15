using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamApp.Application.Dtos.ExamConfiguration
{
    public class ExamConfigurationDto
    {
        public TimeSpan Duration { get; set; }
        public int NumberOfQuestion { get; set; }
    }
}

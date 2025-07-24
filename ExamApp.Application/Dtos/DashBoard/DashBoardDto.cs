using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamApp.Application.Dtos.DashBoard
{
    public class DashBoardDto
    {
        public int TotalStudents { get; set; }
        public int TotalExamsSubmitted { get; set; }
        public int TotalPassedExams { get; set; }
        public int TotalFailedExams { get; set; }
    }
}

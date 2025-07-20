using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamApp.Application.Dtos.ExamRecord
{
    public class ExamRecordDto
    {
        public int Id { get; set; }
        public string StudentName { get; set; }
        public string SubjectName { get; set; }
        public decimal Score { get; set; }
        public DateTime DateTime { get; set; }
    }
}

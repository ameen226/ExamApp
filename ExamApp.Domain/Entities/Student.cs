using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Runtime.ExceptionServices;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace ExamApp.Domain.Entities
{
    public class Student
    {
        public string Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public bool Enabled { get; set; }
        public ICollection<Subject> Subjects { get; set; } = new List<Subject>();
        public ICollection<ExamRecord> ExamRecords { get; set; } = new List<ExamRecord>();
    }
}

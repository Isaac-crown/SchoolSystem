using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolSystem.Domain.Entities
{
    public class Teacher
    {
        public int Id { get; set; }

        public string? NationalIdNumber { get; set; }
        public string? Title { get; set; }
        public string? Name { get; set; }
        public string? Surname { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string? TeacherNumber { get; set; }
        public decimal? Salary { get; set; }
    }
}

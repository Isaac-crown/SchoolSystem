using SchoolSystem.Application.Shared;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolSystem.Application.Dtos
{
    public class TeacherDto
    {
        [Required(ErrorMessage = "NationalIdNumber is a required field.")]
        public string? NationalIdNumber { get; set; }
        [Required(ErrorMessage = "Title is a required field.")]
        public string? Title { get; set; }
        [Required(ErrorMessage = "Name is a required field.")]
        public string? Name { get; set; }
        [Required(ErrorMessage = "Surname is a required field.")]
        public string? Surname { get; set; }
        [Required(ErrorMessage = "DateOfBirth is a required field.")]
        [DataType(DataType.Date)]
        [Display(Name = "Date of Birth")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [MinimumAge(21, ErrorMessage = "Age must not be less than 21")]
        public DateTime DateOfBirth { get; set; }
        [Required(ErrorMessage = "TeacherNumber is a required field.")]
        public string? TeacherNumber { get; set; }
        public decimal? Salary { get; set; }
    }
}

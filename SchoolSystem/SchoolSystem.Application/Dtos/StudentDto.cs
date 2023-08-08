using SchoolSystem.Application.Shared;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace SchoolSystem.Application.Dtos
{
    public class StudentDto
    {
        [Required(ErrorMessage = "NationalIdNumber is a required field.")]
        public string? NationalIdNumber { get; set; }
        [Required(ErrorMessage = "Name is a required field.")]
        public string? Name { get; set; }
        [Required(ErrorMessage = "Surname is a required field.")]
        public string? Surname { get; set; }
        [Required(ErrorMessage = "DateOfBirth is a required field.")]
        [DataType(DataType.Date)]
        [Display(Name = "Date of Birth")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [MaximumAge(22, ErrorMessage = "Age must not be greater than 22")]
        public DateTime DateOfBirth { get; set; }
        [Required(ErrorMessage = "StudentNumber is a required field.")]
        public string? StudentNumber { get; set; }
    }
}

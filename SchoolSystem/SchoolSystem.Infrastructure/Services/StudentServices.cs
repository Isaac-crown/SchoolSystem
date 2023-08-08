using SchoolSystem.Application.Dtos;
using SchoolSystem.Application.Interface;
using SchoolSystem.Application.Service.Interface;
using SchoolSystem.Application.Shared;
using SchoolSystem.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolSystem.Infrastructure.Services
{
    public class StudentServices : IStudentServices
    {
        private readonly IRepositoryManager _repositoryManager;

        public StudentServices(IRepositoryManager repositoryManager)
        {
            _repositoryManager = repositoryManager;
        }
        public async Task<GenericResponse<StudentDto>> CreateStudent(StudentDto student)
        {
            try
            {
                var checkuser = await _repositoryManager.StudentRepository.GetByStudentNumber(student.StudentNumber, false);

                if (checkuser != null) 
                {
                    return new GenericResponse<StudentDto>
                    {
                        ResponseCode = "02",
                        IsSuccessful = false,
                        ResponseMessage = "Student details already exist",
                        Data = null
                    };
                }

                else
                {
                    var addstudent = new Student
                    {
                        DateOfBirth = student.DateOfBirth,
                        NationalIdNumber = student.NationalIdNumber,
                        Name = student.Name,
                        StudentNumber = student.StudentNumber,
                        Surname = student.Surname,

                    };

                    _repositoryManager.StudentRepository.AddStudentDetials(addstudent);
                   await _repositoryManager.SaveAsync();

                    return new GenericResponse<StudentDto>
                    {
                         ResponseCode = "00",
                         ResponseMessage = "Student details created successfully",
                         IsSuccessful = true,
                          Data= student
                    };


                }

            }
            catch (Exception ex)
            {
                return new GenericResponse<StudentDto>
                {
                     ResponseCode = "99",
                      IsSuccessful = false,
                       ResponseMessage= "An error occured while creating user",
                        Data = null
                };
            }
        }
    }
}

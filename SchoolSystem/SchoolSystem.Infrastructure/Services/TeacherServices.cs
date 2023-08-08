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
    public class TeacherServices : ITeacherServices
    {
        private readonly IRepositoryManager _repositoryManager;

        public TeacherServices(IRepositoryManager repositoryManager) 
        {
            _repositoryManager = repositoryManager;
        }

        public async Task<GenericResponse<TeacherDto>> CreateTeacher(TeacherDto dto)
        {
            try
            {
                var checkuser = await _repositoryManager.TeacherRepository.GetByTeacherNo(dto.TeacherNumber, false);

                if (checkuser != null)
                {
                    return new GenericResponse<TeacherDto>
                    {
                        ResponseCode = "02",
                        IsSuccessful = false,
                        ResponseMessage = "Teacher details  already exist",
                        Data = null
                    };
                }

                else
                {
                    var addteacher = new Teacher
                    {
                        DateOfBirth = dto.DateOfBirth,
                        NationalIdNumber = dto.NationalIdNumber,
                        Name = dto.Name,
                        TeacherNumber = dto.TeacherNumber,
                        Surname = dto.Surname,
                        Salary = dto.Salary,
                        Title = dto.Title

                    };

                    _repositoryManager.TeacherRepository.AddTeacherDetails(addteacher);
                    await _repositoryManager.SaveAsync();

                    return new GenericResponse<TeacherDto>
                    {
                        ResponseCode = "00",
                        ResponseMessage = "Teacher details created successfully",
                        IsSuccessful = true,
                        Data = dto
                    };


                }

            }
            catch (Exception ex)
            {
                return new GenericResponse<TeacherDto>
                {
                    ResponseCode = "99",
                    IsSuccessful = false,
                    ResponseMessage = "An error occured while creating user",
                    Data = null
                };
            }
        }
    }
}

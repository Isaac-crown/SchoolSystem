using Microsoft.EntityFrameworkCore;
using Moq;
using SchoolSystem.Application.Interface;
using SchoolSystem.Domain.Entities;
using SchoolSystem.Infrastructure.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTests
{
    public class StudentRepoTest
    {

        [Fact]
        public async Task AddTeacherDetails_ValidTeacher_CallsCreateMethod()
        {
            // Arrange
            var studentdetials = new Student
            {
                Name = "Isaac",
                NationalIdNumber = "223333",
                DateOfBirth = new DateTime(2000, 05, 26),
                StudentNumber = "5565",
                  Surname = "Adeoit",
                  
             

            };

            var mockDbSet = new Mock<DbSet<Student>>();
            var mockDbContext = new Mock<RepositoryContext>();
            mockDbContext.Setup(c => c.Set<Student>()).Returns(mockDbSet.Object);

            var teacherRepository = new StudentRepository(mockDbContext.Object);

            // Act
            teacherRepository.AddStudentDetials(studentdetials);

            // Assert
            mockDbSet.Verify(dbSet => dbSet.AddAsync(It.IsAny<Student>(), default), Times.Once);
            mockDbContext.Verify(context => context.SaveChangesAsync(default), Times.Once);
        }
    }
}

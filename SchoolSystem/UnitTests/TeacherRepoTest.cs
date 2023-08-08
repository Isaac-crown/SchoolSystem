using System.Collections.Generic;
using System;
using SchoolSystem.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using SchoolSystem.Infrastructure.Repository;
using Moq;

namespace UnitTests
{
   public class TeacherRepoTest
{
    [Fact]
    public async Task AddTeacherDetails_ValidTeacher_CallsCreateMethod()
    {
        // Arrange
        var teacher = new Teacher
        {
            Name = "Isaac",
            NationalIdNumber = "223333",
            DateOfBirth = new DateTime(1996, 05, 26),
            Salary = 30000,
            TeacherNumber = "4454",
            Surname = "Adeola",
            Title = "Mr",
        };

        var mockDbSet = new Mock<DbSet<Teacher>>();
        mockDbSet.Setup(c => c.AddAsync(It.IsAny<Teacher>(), default)).Returns(Task.CompletedTask);

        var mockDbContext = new Mock<RepositoryContext>();
        mockDbContext.Setup(c => c.Teachers).Returns(mockDbSet.Object);

        var teacherRepository = new TeacherRepository(mockDbContext.Object);

        // Act
        teacherRepository.AddTeacherDetails(teacher);

        // Assert
        mockDbSet.Verify(dbSet => dbSet.AddAsync(It.IsAny<Teacher>(), default), Times.Once);
        mockDbContext.Verify(context => context.SaveChangesAsync(default), Times.Once);
    }
}

}

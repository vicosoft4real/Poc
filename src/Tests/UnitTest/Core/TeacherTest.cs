using Core.Entity;
using Core.Exception;
using Core.ValueObject;

namespace Tests.UnitTest.Core;

public class TeacherTest
{
    [Fact]
    public void Test_Teacher_Age_Is_Valid_If_Above_22()
    {
        // Arrange
        string firstName = "John";
        string surName = "Doe";
        DateTimeOffset dateOfBirth = DateTimeOffset.UtcNow.AddYears(-22);
        string teachNumber = "123";
        Money salary = new Money(1000, "NGN");
        Guid titleId = Guid.NewGuid();

        // Act
        var teacher = new Teacher(firstName,
            surName, 
            dateOfBirth,
            teachNumber, salary, titleId);
        
        // Assert
        Assert.Equal(firstName, teacher.FirstName);
        Assert.Equal(surName, teacher.SurName);
        Assert.Equal(dateOfBirth, teacher.DateOfBirth);
        Assert.Equal(teachNumber, teacher.TeachNumber);
        Assert.Equal(salary, teacher.Salary);
        Assert.Equal(titleId, teacher.TitleId);
    }
    
    
    [Fact]
    public void Test_Teacher_Throws_Exception_If_Age_Is_Below_22()
    {
        // Arrange
        string firstName = "John";
        string surName = "Doe";
        DateTimeOffset dateOfBirth = DateTimeOffset.UtcNow.AddYears(-10);
        string teachNumber = "123";
        Money salary = new Money(1000, "NGN");
        Guid titleId = Guid.NewGuid();

        // Act && Assert
        Assert.Throws<InvalidAgeException>(() => new Teacher(firstName,
            surName,
            dateOfBirth,
            teachNumber, salary, titleId));
    }
}
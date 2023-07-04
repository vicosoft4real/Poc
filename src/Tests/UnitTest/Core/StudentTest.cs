using Core.Entity;
using Core.Exception;

namespace Tests.UnitTest.Core;

public class StudentTest
{
    [Fact]
    public void Test_Student_Age_Is_Valid_If_Below_22()
    {
        // Arrange
        string firstName = "John";
        string surName = "Doe";
        DateTimeOffset dateOfBirth = DateTimeOffset.UtcNow.AddYears(-18);
        string nationalId = "123";
        string studentNumber = "123";

        // Act
        var student = new Student(firstName,
            surName, 
            dateOfBirth,
            nationalId, studentNumber);
        
        // Assert
        Assert.Equal(firstName, student.FirstName);
        Assert.Equal(surName, student.SurName);
        Assert.Equal(dateOfBirth, student.DateOfBirth);
        Assert.Equal(nationalId, student.NationalId);
        Assert.Equal(studentNumber, student.StudentNumber);
    }
    
    [Fact]
    public void Test_Student_Throws_Exception_If_Age_Is_Above_22()
    {
        // Arrange
        string firstName = "John";
        string surName = "Doe";
        DateTimeOffset dateOfBirth = DateTimeOffset.UtcNow.AddYears(-23);
        string nationalId = "123";
        string studentNumber = "123";

        // Act && Assert
        Assert.Throws<InvalidAgeException>(() => new Student(firstName,
            surName,
            dateOfBirth,
            nationalId, studentNumber));
    }
}
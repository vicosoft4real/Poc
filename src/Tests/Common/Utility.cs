using Application.Students.Create;
using Application.Teachers.Create;
using Core.ValueObject;

namespace Tests.Common;

public class Utility
{
    public static TeacherCreateRequest GetTeacherCreateRequest()
    {
        string firstName = "John";
        string surName = "Doe";
        DateTimeOffset dateOfBirth = DateTimeOffset.UtcNow.AddYears(-22);
        string teachNumber = "123";
        Money salary = new Money(1000, "NGN");
        Guid titleId = Guid.NewGuid();

        var request = new TeacherCreateRequest(firstName, surName, dateOfBirth, teachNumber, salary, titleId);
        return request;
    }
    
    public static TeacherCreateRequest GetTeacherCreateRequest(Guid titleId)
    {
        string firstName = "John";
        string surName = "Doe";
        DateTimeOffset dateOfBirth = DateTimeOffset.UtcNow.AddYears(-22);
        string teachNumber = "123";
        Money salary = new Money(1000, "NGN");

        var request = new TeacherCreateRequest(firstName, surName, dateOfBirth, teachNumber, salary, titleId);
        return request;
    }
    
    public static TeacherCreateRequest GetTeacherCreateRequest(int age, Guid titleId)
    {
        string firstName = "John";
        string surName = "Doe";
        DateTimeOffset dateOfBirth = DateTimeOffset.UtcNow.AddYears(age);
        string teachNumber = "123";
        Money salary = new Money(1000, "NGN");


        var request = new TeacherCreateRequest(firstName, surName, dateOfBirth, teachNumber, salary, titleId);
        return request;
    }
    
    public static StudentCreateRequest GetStudentCreateRequest(int age=-22)
    {
        string firstName = "John";
        string surName = "Doe";
        DateTimeOffset dateOfBirth = DateTimeOffset.UtcNow.AddYears(age);
        string matricNumber = "123";
        string jambRegistrationNumber = "123";

        var request = new StudentCreateRequest(firstName, surName, dateOfBirth, matricNumber, jambRegistrationNumber);
        return request;
    }
}
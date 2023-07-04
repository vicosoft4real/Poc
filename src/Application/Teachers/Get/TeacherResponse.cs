using Core.ValueObject;

namespace Application.Teachers.Get;

public record TeacherResponse(string FirstName,
    string SurName,
    DateTimeOffset DateOfBirth,
    string TeachNumber,
    Money? Salary,
    string TitleName);
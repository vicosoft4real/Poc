using Core.ValueObject;

namespace Application.Teachers.Get;

/// <summary>
/// 
/// </summary>
/// <param name="Id"></param>
/// <param name="FirstName"></param>
/// <param name="SurName"></param>
/// <param name="DateOfBirth"></param>
/// <param name="TeachNumber"></param>
/// <param name="Salary"></param>
/// <param name="TitleName"></param>
public record TeacherResponse(Guid Id, string FirstName,
    string SurName,
    DateTimeOffset DateOfBirth,
    string TeachNumber,
    Money? Salary,
    string TitleName);
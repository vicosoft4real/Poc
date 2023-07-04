using Application.Teachers.Create;
using Application.Teachers.Get;
using Ardalis.GuardClauses;
using Core.Entity;

namespace Application.Teachers.Mapper;

public static class TeacherExtension
{
    public static Teacher MapToEntity(this TeacherCreateRequest teacher)
    {
        Guard.Against.Null(teacher, nameof(teacher));
        return new Teacher
        (
            teacher.FirstName,
            teacher.SurName,
            teacher.DateOfBirth,
            teacher.TeachNumber,
            teacher.Salary,
            teacher.TitleId
        );

    }
    
    public static TeacherResponse MapToResponse(this Teacher teacher)
    {
        Guard.Against.Null(teacher, nameof(teacher));
        return new TeacherResponse
        (
            teacher.FirstName,
            teacher.SurName,
            teacher.DateOfBirth,
            teacher.TeachNumber,
            teacher.Salary,
            teacher.Title?.Name!
        );

    }
    
    
}
using Application.Students.Create;
using Core.Entity;

namespace Application.Students.Mapper;

public static class StudentExtension
{
    public static Student MapToEntity(this StudentCreateRequest request)
    {
        return new Student
        (
            request.FirstName,
            request.SurName,
            request.DateOfBirth,
            request.NationalId,
            request.StudentNumber
        );
    }
}
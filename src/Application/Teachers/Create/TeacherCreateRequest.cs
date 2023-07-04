using Core.ValueObject;
using FluentValidation;
using MediatR;

namespace Application.Teachers.Create;

public record TeacherCreateRequest(
    string FirstName,
    string SurName,
    DateTimeOffset DateOfBirth,
    string TeachNumber,
    Money? Salary,
    Guid TitleId) : IRequest<(bool Succeed, string[] Errors)>
{
    public  TeacherCreateRequestValidator GetValidationInstance()
    {
       return new TeacherCreateRequestValidator();
    }
}

public class TeacherCreateRequestValidator : AbstractValidator<TeacherCreateRequest>
{
    public TeacherCreateRequestValidator()
    {
        RuleFor(x => x.FirstName).NotEmpty().WithMessage("First name is required");
        RuleFor(x => x.SurName).NotEmpty().WithMessage("Surname is required");
        RuleFor(x => x.DateOfBirth)
            .LessThanOrEqualTo(DateTimeOffset.UtcNow.AddYears(-22))
            .WithMessage("Date of birth is required and must be greater than 22 years old");
        RuleFor(x => x.TeachNumber).NotEmpty().WithMessage("Teacher number is required");
        RuleFor(x => x.TitleId).NotEmpty().WithMessage("Title is required");
    }
}    
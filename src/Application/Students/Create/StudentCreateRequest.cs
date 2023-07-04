using FluentValidation;
using MediatR;

namespace Application.Students.Create;

public record StudentCreateRequest(
    string FirstName,
    string SurName,
    DateTimeOffset DateOfBirth,
    string NationalId,
    string StudentNumber) : IRequest<(bool Succeed, string[] Errors)>
{
    public StudentCreateRequestValidator GetValidationInstance()
    {
        return new StudentCreateRequestValidator();
    }
    
}

public class StudentCreateRequestValidator : AbstractValidator<StudentCreateRequest>
{
    public StudentCreateRequestValidator()
    {
        RuleFor(x => x.FirstName).NotEmpty().WithMessage("First name is required");
        RuleFor(x => x.SurName).NotEmpty().WithMessage("Surname is required");
        RuleFor(x => x.DateOfBirth)
            .InclusiveBetween(DateTimeOffset.UtcNow.AddYears(-22).Date,DateTimeOffset.UtcNow.Date)
            .WithMessage("Date of birth is required and must be less than 22 years old");
        RuleFor(x => x.NationalId).NotEmpty().WithMessage("National id is required");
        RuleFor(x => x.StudentNumber).NotEmpty().WithMessage("Student number is required");
    }
    
}
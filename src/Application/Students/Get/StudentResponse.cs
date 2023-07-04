namespace Application.Students.Get;

public record StudentResponse(
    Guid Id,
    string FirstName,
    string SurName,
    DateTimeOffset DateOfBirth,
    string NationalId,
    string StudentNumber);

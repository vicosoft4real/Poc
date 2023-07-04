using MediatR;

namespace Application.Students.Get;

public record GetStudentRequest(): IRequest<List<StudentResponse>>;
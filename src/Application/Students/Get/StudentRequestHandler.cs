using Application.Abstraction;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Students.Get;

public class StudentRequestHandler : IRequestHandler<GetStudentRequest, List<StudentResponse>>
{
    private readonly IApplicationDb _applicationDb;
    public StudentRequestHandler(IApplicationDb applicationDb)
    {
        _applicationDb = applicationDb;
    }
    public async Task<List<StudentResponse>> Handle(GetStudentRequest request, CancellationToken cancellationToken)
    {
        return await (from s in _applicationDb.Students
                select new StudentResponse(s.Id, s.FirstName, s.SurName, s.DateOfBirth, s.NationalId, s.StudentNumber))
            .ToListAsync(cancellationToken: cancellationToken);

    }
}
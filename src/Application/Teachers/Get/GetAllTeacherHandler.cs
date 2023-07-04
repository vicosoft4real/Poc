using Application.Abstraction;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Teachers.Get;

public class GetAllTeacherHandler : IRequestHandler<GetAllTeacherRequest, List<TeacherResponse>>
{
    private readonly IApplicationDb _applicationDb;

    public GetAllTeacherHandler(IApplicationDb applicationDb)
    {
        _applicationDb = applicationDb;
    }
    /// <summary>
    /// 
    /// </summary>
    /// <param name="request"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public async Task<List<TeacherResponse>> Handle(GetAllTeacherRequest request, CancellationToken cancellationToken)
    {
        //todo this can be optimized for pagination
        return await ( from teacher in _applicationDb.Teachers
            join title in _applicationDb.Titles on teacher.TitleId equals title.Id
            select new TeacherResponse(
                teacher.Id,
                teacher.FirstName,
                teacher.SurName,
                teacher.DateOfBirth,
                teacher.TeachNumber,
                teacher.Salary,
                title.Name)).ToListAsync(cancellationToken);
    }
}
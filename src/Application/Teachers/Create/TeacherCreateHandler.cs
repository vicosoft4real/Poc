using Application.Abstraction;
using Application.Teachers.Mapper;
using MediatR;

namespace Application.Teachers.Create;

public class TeacherCreateHandler : IRequestHandler<TeacherCreateRequest, (bool Success, string[] Errors)>
{
    private readonly IApplicationDb _applicationDb;

    public TeacherCreateHandler(IApplicationDb applicationDb)
    {
        _applicationDb = applicationDb;
    }
    public async Task<(bool Success, string[] Errors)> Handle(TeacherCreateRequest request, CancellationToken cancellationToken)
    {
        var validator = request.GetValidationInstance();
        var validate = await validator.ValidateAsync(request, cancellationToken);
        if(!validate.IsValid)
        {
            return (false, validate.Errors.Select(x => x.ErrorMessage).ToArray());
        }
        var teacher = request.MapToEntity();
        _applicationDb.Teachers.Add(teacher);
        return ( await _applicationDb.SaveChangesAsync(cancellationToken)>0, Array.Empty<string>());
    }
}
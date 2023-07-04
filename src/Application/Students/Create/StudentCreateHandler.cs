using Application.Abstraction;
using Application.Students.Mapper;
using MediatR;

namespace Application.Students.Create;

public class StudentCreateHandler: IRequestHandler<StudentCreateRequest, (bool Succeed, string[] Errors)>
{
    private readonly IApplicationDb _applicationDb;
    public StudentCreateHandler(IApplicationDb applicationDb)
    {
        _applicationDb = applicationDb;
    }
    public async Task<(bool Succeed, string[] Errors)> Handle(StudentCreateRequest request, CancellationToken cancellationToken)
    {
        var validator = request.GetValidationInstance();
        var validate = await validator.ValidateAsync(request, cancellationToken);
        if (!validate.IsValid)
        {
            return (false, validate.Errors.Select(x => x.ErrorMessage).ToArray());
        }
        var student = request.MapToEntity();
        _applicationDb.Students.Add(student);
        return (await _applicationDb.SaveChangesAsync(cancellationToken) > 0, Array.Empty<string>());
    }
}
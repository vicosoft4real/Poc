using Application.Abstraction;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Titles.Get;

public class GetTitleHandler : IRequestHandler<GetTitleRequest, List<TitleResponse>>
{
    private readonly IApplicationDb _applicationDb;

    public GetTitleHandler(IApplicationDb applicationDb)
    {
        _applicationDb = applicationDb;
    }

    public async Task<List<TitleResponse>> Handle(GetTitleRequest request, CancellationToken cancellationToken)
    {
        return await (from t in _applicationDb.Titles select new TitleResponse(t.Id, t.Name)).ToListAsync(
            cancellationToken);
    }
}
using MediatR;

namespace Application.Titles.Get;

public record GetTitleRequest(): IRequest<List<TitleResponse>>;
namespace Application.Abstraction;

public interface IDateTimeProvider
{
    DateTime UtcNow { get; }

    DateTimeOffset UtcNowAsOffset { get; }
}
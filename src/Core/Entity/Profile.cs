namespace Core.Entity;

public abstract class Profile : EntityBase<Guid>
{
    protected Profile(string firstName, string surName, DateTimeOffset dateOfBirth) : base(Guid.NewGuid())
    {
        FirstName = firstName;
        SurName = surName;
        DateOfBirth = dateOfBirth;
    }

    public string FirstName { get; private set; }
    public string SurName { get; private set; }
    public DateTimeOffset DateOfBirth { get; private set; }
    
    public  DateTimeOffset CreatedAt { get; } = DateTimeOffset.UtcNow;
}
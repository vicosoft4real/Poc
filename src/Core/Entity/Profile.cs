using Core.Exception;

namespace Core.Entity;

public abstract class Profile : EntityBase<Guid>
{
    protected Profile(string firstName, string surName, DateTimeOffset dateOfBirth) : base(Guid.NewGuid())
    {
        FirstName = firstName;
        SurName = surName;
        ValidateAge(dateOfBirth);
        DateOfBirth = dateOfBirth;
    }

    public string FirstName { get; private set; }
    public string SurName { get; private set; }
    public DateTimeOffset DateOfBirth { get; private set; }
    
    
    /// <summary>
    /// Validate age of teacher
    /// </summary>
    /// <param name="dateOfBirth"></param>
    /// <exception cref="InvalidAgeException"></exception>
    private void ValidateAge(DateTimeOffset dateOfBirth)
    {
        if (dateOfBirth > DateTimeOffset.UtcNow.AddYears(-22))
        {
            throw new InvalidAgeException("Teacher age must not be less than 21 years old");
        }
    }
}
using Core.Exception;
using Core.ValueObject;

namespace Core.Entity;

public class Teacher : Profile
{
    /// <summary>
    /// Teacher constructor
    /// </summary>
    /// <param name="firstName"></param>
    /// <param name="surName"></param>
    /// <param name="dateOfBirth"></param>
    /// <param name="teachNumber"></param>
    /// <param name="salary"></param>
    /// <param name="titleId"></param>
    public Teacher(string firstName, string surName, DateTimeOffset dateOfBirth, string teachNumber, Money? salary, Guid titleId) :
        base(firstName, surName, dateOfBirth)
    {
        ValidateAge(dateOfBirth);
        TeachNumber = teachNumber;
        Salary = salary;
        TitleId = titleId;

    }


    #region Properties
    
    public string TeachNumber { get; private set; } = null!;
    public Money? Salary { get; private set; }
    public Guid TitleId { get; private set; }
    public Title Title { get; private set; } = null!;

    #endregion
   

    #region Private Methods
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

    /// <summary>
    /// for EF 
    /// </summary>
    private Teacher() : base("", "", DateTimeOffset.UtcNow)
    {
    }
    #endregion
    
    
}
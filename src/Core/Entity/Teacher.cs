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
    /// for EF 
    /// </summary>
    private Teacher() : base("", "", DateTimeOffset.UtcNow)
    {
    }
    #endregion
    
    
}
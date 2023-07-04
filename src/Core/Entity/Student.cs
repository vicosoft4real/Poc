using Core.Exception;

namespace Core.Entity;

public class Student : Profile
{
    /// <summary>
    /// Student constructor
    /// </summary>
    /// <param name="firstName"></param>
    /// <param name="surName"></param>
    /// <param name="dateOfBirth"></param>
    /// <param name="nationalId"></param>
    /// <param name="studentNumber"></param>
    public Student(string firstName, string surName, DateTimeOffset dateOfBirth, string nationalId, string studentNumber) 
        : base(firstName, surName, dateOfBirth)
    {
        ValidateAge(dateOfBirth);
        NationalId = nationalId;
        StudentNumber = studentNumber;
    }

    #region Private Methods
    /// <summary>
    /// For EF
    /// </summary>
    private Student() : base("", "", DateTimeOffset.UtcNow)
    {
    }
    /// <summary>
    /// Validate age of teacher
    /// </summary>
    /// <param name="dateOfBirth"></param>
    /// <exception cref="InvalidAgeException"></exception>
    private void ValidateAge(DateTimeOffset dateOfBirth)
    {
        var minYear=DateTimeOffset.UtcNow.AddYears(-23).Date.Year;
        var currentYear = DateTimeOffset.UtcNow.Date.Year;
        if (dateOfBirth.Date.Year > currentYear || dateOfBirth.Date.Year <= minYear)
        {
            throw new InvalidAgeException("Student age must  be less than 21 years old");
        }
    }
    #endregion
    

    public string NationalId { get; private set; } 
    public string StudentNumber { get; private set; }
    
}
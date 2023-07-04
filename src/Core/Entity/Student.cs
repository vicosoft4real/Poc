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
        NationalId = nationalId;
        StudentNumber = studentNumber;
        ValidateStudentAge(dateOfBirth);
    }

    #region Private Methods
    /// <summary>
    /// For EF
    /// </summary>
    private Student() : base("", "", DateTimeOffset.UtcNow)
    {
    }

    /// <summary>
    /// Validate student age
    /// </summary>
    /// <param name="dateOfBirth"></param>
    /// <exception cref="InvalidAgeException"></exception>
    private void ValidateStudentAge(DateTimeOffset dateOfBirth)
    {
        if (dateOfBirth.AddYears(22) < DateTimeOffset.UtcNow)
        {
            throw new InvalidAgeException("Student age must be less than 22 years old");
        }
    }

    #endregion
    

    public string NationalId { get; private set; } = null!;
    public string StudentNumber { get; private set; } = null!;
    
}
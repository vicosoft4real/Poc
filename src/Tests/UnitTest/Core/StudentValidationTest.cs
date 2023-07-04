using Application.Students.Create;
using FluentValidation.TestHelper;

namespace Tests.UnitTest.Core;

public class StudentValidationTest
{
    private readonly StudentCreateRequestValidator _validator;

    public StudentValidationTest()
    {
        _validator = new StudentCreateRequestValidator();
    }
    
    [Fact]
    public void FirstName_ShouldHaveValidationError_WhenEmpty()
    {
        var request = new StudentCreateRequest(
            "",
            "Doe",
            DateTimeOffset.UtcNow.AddYears(-22), 
            "123",
            "123"); 
            
        var result = _validator.TestValidate(request);
        result.ShouldHaveValidationErrorFor(x => x.FirstName);
    }
    
    [Fact]
    public void ShouldNotHaveAnyValidationErrors_WhenValidRequest()
    {
        var request = new StudentCreateRequest
        (
            "John",
            "Doe",
            DateTimeOffset.Now.AddYears(-18),
            "123",
            "123"
        );
        var result = _validator.TestValidate(request);
        result.ShouldNotHaveAnyValidationErrors();
    }
    
    [Fact]
    public void ShouldHaveValidationError_WhenDateOfBirthIsGreaterThan22Years()
    {
        var request = new StudentCreateRequest
        (
            "John",
            "Doe",
            DateTimeOffset.Now.AddYears(-23),
            "123",
            "123"
        );
        var result = _validator.TestValidate(request);
        result.ShouldHaveValidationErrorFor(x => x.DateOfBirth);
    }
}
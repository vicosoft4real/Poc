using Application.Teachers.Create;
using Core.ValueObject;
using FluentValidation.TestHelper;

namespace Tests.UnitTest.Core;

public class TeacherValidationTest
{
    private readonly TeacherCreateRequestValidator _validator;

    public TeacherValidationTest()
    {
        _validator = new TeacherCreateRequestValidator();
    }
    
    [Fact]
    public void FirstName_ShouldHaveValidationError_WhenEmpty()
    {
        var request = new TeacherCreateRequest(
            "",
            "Doe",
            DateTimeOffset.UtcNow.AddYears(-22), 
            "123",
            new Money(1000, "NGN"), Guid.NewGuid()); 
            
        var result = _validator.TestValidate(request);
        result.ShouldHaveValidationErrorFor(x => x.FirstName);
    }
    [Fact]
    public void ShouldNotHaveAnyValidationErrors_WhenValidRequest()
    {
        var request = new TeacherCreateRequest
        (
            "John",
            "Doe",
            DateTimeOffset.Now.AddYears(-23),
            "123",
            new Money(1000, "NGN"),
            Guid.NewGuid()
        );
        var result = _validator.TestValidate(request);
        result.ShouldNotHaveAnyValidationErrors();
    }
    
    [Fact]
    public void ShouldHaveValidationError_WhenDateOfBirthIsLessThan22Years()
    {
        var request = new TeacherCreateRequest
        (
            "John",
            "Doe",
            DateTimeOffset.Now.AddYears(-21),
            "123",
            new Money(1000, "NGN"),
            Guid.NewGuid()
        );
        var result = _validator.TestValidate(request);
        result.ShouldHaveValidationErrorFor(x => x.DateOfBirth);
    }
}
using Application.Abstraction;
using Application.Students.Create;
using NSubstitute;

namespace Tests.UnitTest.Application;

public class StudentCreateHandlerTest
{
    private readonly IApplicationDb _applicationDb;

    public StudentCreateHandlerTest()
    {
        _applicationDb = Substitute.For<IApplicationDb>();
        
    }
    
    [Fact]
    public async Task Test_StudentCreateHandler_WhenStudentIsCreated_ShouldReturn_success()
    {
        //Arrange
        _applicationDb.SaveChangesAsync(Arg.Any<CancellationToken>()).Returns(1);
        var handler = new StudentCreateHandler(_applicationDb);
        
        var request = StudentCreateRequest();

        //Act
        var response = await handler.Handle(request, CancellationToken.None);
        
        //Assert
        Assert.True(response.Succeed);
         
    }

    [Fact]
    public async Task Test_StudentCreateHandler_WhenStudentIsNotCreated_ShouldReturn_failure()
    {
        _applicationDb.SaveChangesAsync(Arg.Any<CancellationToken>()).Returns(0);
        var handler = new StudentCreateHandler(_applicationDb);

        var request = StudentCreateRequest();

        var response = await handler.Handle(request, CancellationToken.None);

        Assert.False(response.Succeed);
    }
    [Fact]
    public async Task Test_StudentCreateHandler_WhenStudentIsCreated_WithInvalidRecord_ShouldReturn_Errors()
    {
        //Arrange
        _applicationDb.SaveChangesAsync(Arg.Any<CancellationToken>()).Returns(1);
        var handler = new StudentCreateHandler(_applicationDb);
        
        string firstName = "";
        string surName = "";
        DateTimeOffset dateOfBirth = DateTimeOffset.UtcNow.AddYears(-23);
        string matricNumber = "123";
        string jambRegistrationNumber = "123";
        
        var request = new StudentCreateRequest(firstName, surName, dateOfBirth, matricNumber, jambRegistrationNumber);

        //Act
        var response = await handler.Handle(request, CancellationToken.None);
        
        //Assert
       Assert.True(response.Errors.Length > 0);
         
    }


    private static StudentCreateRequest StudentCreateRequest()
    {
        string firstName = "John";
        string surName = "Doe";
        DateTimeOffset dateOfBirth = DateTimeOffset.UtcNow.AddYears(-22);
        string matricNumber = "123";
        string jambRegistrationNumber = "123";

        var request = new StudentCreateRequest(firstName, surName, dateOfBirth, matricNumber, jambRegistrationNumber);
        return request;
    }
}
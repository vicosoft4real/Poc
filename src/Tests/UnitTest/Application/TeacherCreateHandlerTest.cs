using Application.Abstraction;
using Application.Teachers.Create;
using Core.ValueObject;
using NSubstitute;
namespace Tests.UnitTest.Application;

public class TeacherCreateHandlerTest
{
    private readonly IApplicationDb _applicationDb;

    public TeacherCreateHandlerTest()
    {
        _applicationDb = Substitute.For<IApplicationDb>();
        
    }

    [Fact]
    public async Task Test_TeacherCreateHandler_WhenTeacherIsCreated_ShouldReturn_success()
    {
        //Arrange
        _applicationDb.SaveChangesAsync(Arg.Any<CancellationToken>()).Returns(1);
        var handler = new TeacherCreateHandler(_applicationDb);
        
        var request = TeacherCreateRequest();

        //Act
        var response = await handler.Handle(request, CancellationToken.None);
        
        //Assert
        Assert.True(response.Success);
         
    }

    

    [Fact]
    public async Task Test_TeacherCreateHandler_WhenTeacherIsNotCreated_ShouldReturn_failure()
    {
        _applicationDb.SaveChangesAsync(Arg.Any<CancellationToken>()).Returns(0);
        var handler = new TeacherCreateHandler(_applicationDb);
        
        var request = TeacherCreateRequest();
        
        var response = await handler.Handle(request, CancellationToken.None);
        
        Assert.False(response.Success);

    }
    
    
    private static TeacherCreateRequest TeacherCreateRequest()
    {
        string firstName = "John";
        string surName = "Doe";
        DateTimeOffset dateOfBirth = DateTimeOffset.UtcNow.AddYears(-22);
        string teachNumber = "123";
        Money salary = new Money(1000, "NGN");
        Guid titleId = Guid.NewGuid();

        var request = new TeacherCreateRequest(firstName, surName, dateOfBirth, teachNumber, salary, titleId);
        return request;
    }
}
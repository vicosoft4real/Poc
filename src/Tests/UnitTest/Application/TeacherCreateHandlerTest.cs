using Application.Abstraction;
using Application.Teachers.Create;
using NSubstitute;
using Tests.Common;

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
        
        var request = Utility.GetTeacherCreateRequest();

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
        
        var request = Utility.GetTeacherCreateRequest();
        
        var response = await handler.Handle(request, CancellationToken.None);
        
        Assert.False(response.Success);

    }
    
    

}
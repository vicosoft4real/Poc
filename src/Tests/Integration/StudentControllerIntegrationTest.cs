using System.Text;
using Application.Students.Create;
using Newtonsoft.Json;
using Tests.Common;

namespace Tests.Integration;

public class StudentControllerIntegrationTest : IClassFixture<CustomWebApplicationFactory<Program>>
{
    private readonly HttpClient _client;

    public StudentControllerIntegrationTest(CustomWebApplicationFactory<Program> factory)
    {
        _client = factory.CreateClient();
    }
    
    [Fact]
    public async Task GetAllStudents_WhenCalled_ShouldReturn_200()
    {
        var response = await _client.GetAsync("/Student");
        response.EnsureSuccessStatusCode();
    
        Assert.Equal(200, (int)response.StatusCode);
    }
    [Fact]
    public async Task CreateStudent_WhenCalled_ShouldReturn_201()
    {
        //arrange
        var student = Utility.GetStudentCreateRequest();
        var content = new StringContent(JsonConvert.SerializeObject(student), Encoding.UTF8, "application/json");
        
        //act
        var response = await _client.PostAsync("/Student", content);
        
        //assert
        response.EnsureSuccessStatusCode();
    
        Assert.Equal(201, (int)response.StatusCode);
    }

    [Fact]
    public async Task CreateStudent_With_Invalid_Age_ShouldReturn_400()
    {
        //arrange
        var student = Utility.GetStudentCreateRequest(23);
        var content = new StringContent(JsonConvert.SerializeObject(student), Encoding.UTF8, "application/json");
        
        //act
        var response = await _client.PostAsync("/Student", content);
        var result = JsonConvert.DeserializeObject<string[]>(await response.Content.ReadAsStringAsync());
        
        //assert
        Assert.Equal(400, (int)response.StatusCode);
        Assert.Contains("Date of birth is required and must not be more than 22 years", result);
    }
    
    [Theory]
    [InlineData("", "", "", "")]
    public async Task CreateStudent_With_Invalid_Input_ShouldReturn_400(string fname, string sname, string nationalId, string studentNumber)
    {
        //arrange
        var student = new StudentCreateRequest(fname, sname,DateTime.Now.AddYears(-20), nationalId, studentNumber);
        var content = new StringContent(JsonConvert.SerializeObject(student), Encoding.UTF8, "application/json");
        
        //act
        var response = await _client.PostAsync("/Student", content);
        var result = JsonConvert.DeserializeObject<string[]>(await response.Content.ReadAsStringAsync());
        
        //assert
        Assert.Equal(400, (int)response.StatusCode);
        Assert.Contains("First name is required", result);
        Assert.Contains("Surname is required", result);
        Assert.Contains("National id is required", result);
        Assert.Contains("Student number is required", result);
    }
}
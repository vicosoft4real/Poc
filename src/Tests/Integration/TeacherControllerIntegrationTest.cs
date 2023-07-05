using System.Text;
using Application.Teachers.Create;
using Application.Titles.Get;
using Core.ValueObject;
using Newtonsoft.Json;
using Tests.Common;

namespace Tests.Integration;

public class TeacherControllerIntegrationTest :  IClassFixture<CustomWebApplicationFactory<Program>>
{
    private readonly HttpClient _client;

    public TeacherControllerIntegrationTest(CustomWebApplicationFactory<Program> factory)
    {
        _client = factory.CreateClient();
    }

    [Fact]
    public async Task GetAllTeachers_WhenCalled_ShouldReturn_200()
    {
        var response = await _client.GetAsync("/Teacher");
        response.EnsureSuccessStatusCode();
   
        Assert.Equal(200, (int)response.StatusCode);
    }
    [Fact]
    public async Task CreateTeacher_WhenCalled_ShouldReturn_201()
    {
        //arrange
        var title = await _client.GetAsync("/Title");
        var titles = JsonConvert.DeserializeObject<List<TitleResponse>>(await title.Content.ReadAsStringAsync());
        var titleId = titles.FirstOrDefault()?.Id;
        var teacher = Utility.GetTeacherCreateRequest(titleId.GetValueOrDefault());
        var content = new StringContent(JsonConvert.SerializeObject(teacher), Encoding.UTF8, "application/json");
        
        //act
        var response = await _client.PostAsync("/Teacher", content);
        
        //assert
        response.EnsureSuccessStatusCode();
   
        Assert.Equal(201, (int)response.StatusCode);
    }

    [Fact]
    public async Task CreateTeacher_With_Invalid_Age_ShouldReturn_400()
    {
        //arrange
        var title = await _client.GetAsync("/Title");
        var titles = JsonConvert.DeserializeObject<List<TitleResponse>>(await title.Content.ReadAsStringAsync());
        var titleId = titles.FirstOrDefault()?.Id;
        var teacher = Utility.GetTeacherCreateRequest(18, titleId.GetValueOrDefault());

        var content = new StringContent(JsonConvert.SerializeObject(teacher), Encoding.UTF8, "application/json");

        //act
        var response = await _client.PostAsync("/Teacher", content);
        var result = JsonConvert.DeserializeObject<string[]>(await response.Content.ReadAsStringAsync());

        //assert
        Assert.Equal(400, (int)response.StatusCode);
        Assert.Contains("Date of birth is required and must be greater than 22 years old", result);
    }

    [Theory]
    [InlineData("", "", "")]
    public async Task CreateTeacher_With_Invalid_Input_ShouldReturn_400(string firstName, string surName,
        string teacherNo)
    {
        //arrange

        var teacher = new TeacherCreateRequest(firstName,
            surName,
            DateTime.Now.AddYears(-20),
            teacherNo,
            new Money(100, "NGN"), Guid.Empty);
        var content = new StringContent(JsonConvert.SerializeObject(teacher), Encoding.UTF8, "application/json");

        //act
        var response = await _client.PostAsync("/Teacher", content);
        var result = JsonConvert.DeserializeObject<string[]>(await response.Content.ReadAsStringAsync());

        //assert
        Assert.Equal(400, (int)response.StatusCode);
        Assert.Contains("Teacher number is required", result);
        Assert.Contains("First name is required", result);
        Assert.Contains("Surname is required", result);
        Assert.Contains("Title is required", result);
    }

}
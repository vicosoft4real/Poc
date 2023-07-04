using Application.Students.Create;
using Application.Students.Get;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Presentation.Controllers;

[ApiController]
[Route("[controller]")]
public class StudentController : ControllerBase
{
    private readonly IMediator _mediator;

    public StudentController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    [ProducesDefaultResponseType(typeof(List<StudentResponse>))]
    public async Task<IActionResult> Get()
    {
        var response = await _mediator.Send(new GetStudentRequest());

        return Ok(response);
    }
    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string[]))]
    public async Task<IActionResult> Post([FromBody] StudentCreateRequest request)
    {
        var response = await _mediator.Send(request);
        if (response.Succeed)
        {
            return Created($"/student/{request.StudentNumber}", response);
        }

        return BadRequest(response.Errors);
    }
}
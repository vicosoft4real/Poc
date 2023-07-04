using Application.Teachers.Create;
using Application.Teachers.Get;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Presentation.Controllers;

[ApiController]
[Route("[controller]")]
public class TeacherController : ControllerBase
{
    private readonly IMediator _mediator;

    public TeacherController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpPost]
    public async Task<IActionResult> Post([FromBody] TeacherCreateRequest request)
    {
        var response = await _mediator.Send(request);
        if(response.Success)
        {
            return Created("", response);
        }

        return BadRequest(response.Errors);
    }
    
    [HttpGet]
    public async Task<IActionResult> Get()
    {
        var response = await _mediator.Send(new GetAllTeacherRequest());
        
        return Ok(response);
    }
}
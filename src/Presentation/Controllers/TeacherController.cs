using Application.Teachers.Create;
using Application.Teachers.Get;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Presentation.Controllers;


public class TeacherController : BaseController
{
    private readonly IMediator _mediator;

    public TeacherController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string[]))]
    public async Task<IActionResult> Post([FromBody] TeacherCreateRequest request)
    {
        var response = await _mediator.Send(request);
        if(response.Succeed)
        {
            return Created($"/teacher/{request.TeachNumber}", response);
        }

        return BadRequest(response.Errors);
    }
    
    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesDefaultResponseType(typeof(List<TeacherResponse>))]
    public async Task<IActionResult> Get()
    {
        var response = await _mediator.Send(new GetAllTeacherRequest());
        
        return Ok(response);
    }
}
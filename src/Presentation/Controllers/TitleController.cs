using Application.Titles.Get;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Presentation.Controllers;

[ApiController]
[Route("[controller]")]
public class TitleController : ControllerBase
{
    private readonly IMediator _mediator;

    public TitleController(IMediator mediator)
    {
        _mediator = mediator;
    }
    
    
    [HttpGet]
    public async Task<IActionResult> Get()
    {
        var response = await _mediator.Send(new GetTitleRequest());
        
        return Ok(response);
    }
}
using MediatR;
using Microsoft.AspNetCore.Mvc;
using PickPoint.Contracts.Exceptions;
using PickPoint.Contracts.Postomat;

namespace PickPoint.WebApi.Controllers;

[Route("[controller]")]
[ApiController]
public class PostomatController : ControllerBase
{
    private readonly IMediator _mediator;

    public PostomatController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> Get(int id)
    {
        try
        {
            var request = new PostomatInfoRequest(id);
            var reply = await _mediator.Send(request);

            return Ok(reply);
        }
        catch (ItemNotFoundException e)
        {
            return NotFound(e.Message);
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }
    
    [HttpGet]
    public async Task<IActionResult> Get()
    {
        try
        {
            var request = new PostomatGetAllRequest();
            var reply = await _mediator.Send(request);

            return Ok(reply);
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }
}
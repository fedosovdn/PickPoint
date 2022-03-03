using MediatR;
using Microsoft.AspNetCore.Mvc;
using PickPoint.Contracts.Exceptions;
using PickPoint.Contracts.Order;
using PickPoint.WebApi.Order;

namespace PickPoint.WebApi.Controllers;

[Route("[controller]")]
[ApiController]
public class OrderController : ControllerBase
{
    private readonly IMediator _mediator;

    public OrderController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> Get(int id)
    {
        try
        {
            var request = new OrderInfoRequest(id);
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

    [HttpPut]
    public async Task<IActionResult> Create([FromBody] OrderCreateRequest request)
    {
        try
        {
            var orderCreateRequest = new OrderCreateCommand(request.OrderDto);
            await _mediator.Send(orderCreateRequest);

            return Ok();
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }
    
    [HttpPost("[action]")]
    public async Task<IActionResult> Cancel([FromBody] OrderCancelRequest request)
    {
        try
        {
            var orderCreateRequest = new OrderCancelCommand(request.Id);
            await _mediator.Send(orderCreateRequest);

            return Ok();
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
    
    [HttpPatch]
    public async Task<IActionResult> Update([FromBody] OrderUpdateRequest request)
    {
        try
        {
            var orderCreateRequest = new OrderUpdateCommand(request.OrderDto);
            await _mediator.Send(orderCreateRequest);

            return Ok();
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
}
using MediatR;
using Microsoft.AspNetCore.Mvc;
using OrderService.API.Application.Queries.QueryModels;
using System;
using System.Threading.Tasks;

namespace OrderService.API.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        private readonly IMediator _mediator;
        public OrdersController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("infor")]
        public async Task<IActionResult> Get()
        {
            return Ok("Order service infor");
        }

        [HttpGet("")]
        public async Task<IActionResult> GetOrders([FromQuery] GetOrdersQuery query)
        {
            return Ok(await _mediator.Send(query));
        }

        [HttpGet("userId/{id}")]
        public async Task<IActionResult> GetOrdersByUserId([FromRoute]Guid id, [FromQuery] GetOrdersByUserIdQuery query)
        {
            query.UserId = id;
            return Ok(await _mediator.Send(query));
        }
    }
}

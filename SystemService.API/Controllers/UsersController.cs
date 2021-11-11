using MediatR;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using SystemService.API.Application.Commands.CommandModels;
using SystemService.API.Application.Queries.QueryModels;

namespace SystemService.API.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    [EnableCors("MyPolicy")]
    public class UsersController : ControllerBase
    {
        private readonly IMediator _mediator;
        public UsersController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("infor")]
        public async Task<IActionResult> Get()
        {
            return Ok("Order service infor");
        }

        [HttpGet("")]
        public async Task<IActionResult> GetUsers([FromQuery] GetUsersPagingQuery query)
        {
            return Ok(await _mediator.Send(query));
        }
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateUserCommand command)
        {
            return Ok(await _mediator.Send(command));
        }
        [HttpPatch("{id}")]
        public async Task<IActionResult> Edit([FromRoute] Guid id, [FromBody] EditUserCommand command)
        {
            command.Id = id;
            return Ok(await _mediator.Send(command));
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById([FromRoute] Guid id)
        {
            GetUserByIdQuery query = new GetUserByIdQuery();
            query.Id = id;
            return Ok(await _mediator.Send(query));
        }
    }
}

using MediatR;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using SystemService.API.Application.Commands.CommandModels;
using SystemService.API.Application.Queries.QueryModels;

namespace OrderService.API.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    [EnableCors("MyPolicy")]
    public class UserTypesController : ControllerBase
    {
        private readonly IMediator _mediator;
        public UserTypesController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("infor")]
        public async Task<IActionResult> Get()
        {
            return Ok("Order service infor");
        }

        [HttpGet("")]
        public async Task<IActionResult> GetUsers([FromQuery] GetUserTypesPagingQuery query)
        {
            return Ok(await _mediator.Send(query));
        }

        [HttpGet("actions/usertypes-select")]
        public async Task<IActionResult> GetUserTypesSelect([FromQuery] GetUserTypesSelectRequest query)
        {
            return Ok(await _mediator.Send(query));
        }

        [HttpGet("actions/usertype-roles-select")]
        public async Task<IActionResult> GetUserTypeRoles([FromQuery] GetUserTypeRolesSelectRequest query)
        {
            return Ok(await _mediator.Send(query));
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById([FromRoute] Guid id)
        {
            GetUserTypeByIdQuery query = new GetUserTypeByIdQuery();
            query.Id = id;
            return Ok(await _mediator.Send(query));
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateUserTypecommand command)
        {
            return Ok(await _mediator.Send(command));
        }

        [HttpPatch("{id}")]
        public async Task<IActionResult> Edit([FromRoute] Guid id, [FromBody] UpdateUserTypeCommand command)
        {
            command.Id = id;
            return Ok(await _mediator.Send(command));
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete([FromRoute] Guid id, [FromBody] DeleteUserTypeCommand command)
        {
            command.Id = id;
            return Ok(await _mediator.Send(command));
        }
    }
}

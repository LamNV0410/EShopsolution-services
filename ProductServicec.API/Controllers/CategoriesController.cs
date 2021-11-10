using MediatR;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using ProductService.API.Application.CategoryApp.Commands.CommandModels;
using ProductService.API.Application.CategoryApp.Queries;
using System;
using System.Threading.Tasks;

namespace ProductService.API.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    [EnableCors("MyPolicy")]
    public class CategoriesController : ControllerBase
    {
        private readonly IMediator _mediator;
        public CategoriesController(IMediator mediator)
        {
            _mediator = mediator;
        }

        /// <summary>
        /// get all categories
        /// </summary>
        /// <param name="query">query parameter</param>
        /// <returns></returns>
        [HttpGet("")]
        public async Task<IActionResult> GetCategories([FromQuery] GetCategoriesQuery query)
        {
            return Ok(await _mediator.Send(query));
        }

        /// <summary>
        /// Get category by Id
        /// </summary>
        /// <param name="query">query parameter</param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById([FromRoute] Guid id)
        {
            return Ok(await _mediator.Send(new GetCategoryByIdCommand() { Id = id }));
        }

        /// <summary>
        /// Create category
        /// </summary>
        /// <param name="command">param create</param>
        /// <returns></returns>
        [EnableCors("MyPolicy")]
        [HttpPost("")]
        public async Task<IActionResult> Create([FromBody] CreateCategoryCommand command)
        {
            return Ok(await _mediator.Send(command));
        }

        /// <summary>
        /// Update category
        /// </summary>
        /// <param name="id">Id update</param>
        /// <param name="command">Param update</param>
        /// <returns></returns>
        [HttpPatch("{id}")]
        public async Task<IActionResult> Edit([FromRoute] Guid id, [FromBody] UpdateCategoryCommand command)
        {
            command.Id = id;
            return Ok(await _mediator.Send(command));
        }

        /// <summary>
        /// Delete category
        /// </summary>
        /// <param name="id">Id delete</param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete([FromRoute] Guid id)
        {
            return Ok(await _mediator.Send(new DeleteCategoryCommand() { Id = id }));
        }
    }
}

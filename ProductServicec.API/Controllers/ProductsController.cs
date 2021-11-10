using MediatR;
using Microsoft.AspNetCore.Mvc;
using ProductService.API.Application.ProductsApp.Commands.CommandModels;
using ProductService.API.Application.ProductsApp.Queries.QueryModels;
using System;
using System.Threading.Tasks;

namespace ProductService.API.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IMediator _mediator;
        public ProductsController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpGet("infor")]
        public async Task<IActionResult> Get()
        {
            return Ok("ProductService infor");
        }

        /// <summary>
        /// Get all products
        /// </summary>
        /// <param name="query">query parameter</param>
        /// <returns></returns>
        [HttpGet("")]
        public async Task<IActionResult> GetProducts([FromQuery] GetProductsQuery query)
        {
            return Ok(await _mediator.Send(query));
        }

        /// <summary>
        /// Create product
        /// </summary>
        /// <param name="query">query parameter</param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateProductCommand command)
        {
            return Ok(await _mediator.Send(command));
        }

        /// <summary>
        /// Update product
        /// </summary>
        /// <param name = "id" ></ param >
        /// < param name="command"></param>
        /// <returns></returns>
        [HttpPut("{id}")]
        public async Task<IActionResult> Update([FromRoute] Guid id, [FromBody] UpdateProductcommand command)
        {
            command.Id = id;
            return Ok(await _mediator.Send(command));
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProduct([FromRoute] Guid id)
        {
            DeleteProductCommand command = new DeleteProductCommand() { Id = id };
            return Ok(await _mediator.Send(command));
        }
    }
}

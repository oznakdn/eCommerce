using eCommerceAPI.Application.Features.Commands.ProductCommands.AddProduct;
using eCommerceAPI.Application.Features.Commands.ProductCommands.DeleteProduct;
using eCommerceAPI.Application.Features.Commands.ProductCommands.UpdateProduct;
using eCommerceAPI.Application.Features.Queries.ProductQueries.GetAllProducts;
using eCommerceAPI.Application.Features.Queries.ProductQueries.GetProductById;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace eCommerceAPI.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IMediator _mediator;


        public ProductsController(IMediator mediator)
        {
          
            _mediator = mediator;
        }



        [HttpGet]
        [ActionName("GetProducts")]
        public async Task<IActionResult> GetProducts()
        {
            var products = await _mediator.Send(new GetAllProductsQueryRequest());
            return Ok(products);
        }

        [HttpGet("{id}")]
        [ActionName("GetProductById")]
        public async Task<IActionResult> GetProductById(string id)
        {
            var response = await _mediator.Send(new GetProductByIdQueryRequest(id));
            return Ok(response);
        }

        [HttpPost]
        public async Task<IActionResult> AddProduct([FromBody] AddProductCommandRequest request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState.Values.Select(x=>x.Errors.ToArray()));
            }
            var response = await _mediator.Send(request);
            return Ok();
            //return Ok(response.Message);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateProduct([FromBody] UpdateProductCommandRequest request)
        {
            if (ModelState.IsValid)
            {
                var response =await _mediator.Send(request);
                return CreatedAtAction(nameof(GetProductById), new { id = request.Id }, request);
            }
            return BadRequest();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProduct(string id)
        {
            await _mediator.Send(new DeleteProductCommandRequest(id));
            return NoContent();
            //return Ok(request.Message);
        }
    }
}

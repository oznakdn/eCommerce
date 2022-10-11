using eCommerceAPI.Application.UnitOfWork;
using eCommerceAPI.Application.ViewModels.ProductViewModels;
using eCommerceAPI.Domain.Entities;
using eCommerceAPI.Persistence.UnitOfWork;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace eCommerceAPI.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly ICommandUnitOfWork commandUnitOfWork;
        private readonly IQueryUnitOfWork queryUnitOfWork;


        public ProductsController(ICommandUnitOfWork commandUnitOfWork, IQueryUnitOfWork queryUnitOfWork)
        {
            this.commandUnitOfWork = commandUnitOfWork;
            this.queryUnitOfWork = queryUnitOfWork;
        }






        [HttpGet]
        [ActionName("GetProducts")]
        public async Task<IActionResult> GetProducts()
        {
            var products = queryUnitOfWork.productRead.GetAll(false);
            var result = await products.Select(product => new GetProductsViewModel
            {
                Id = product.Id.ToString(),
                ProductName = product.ProductName,
                Stock = product.Stock,
                Price = product.Price

            }).ToListAsync();

            return Ok(result);
        }

        [HttpGet("{id}")]
        [ActionName("GetProductById")]
        public async Task<IActionResult> GetProductById(string id)
        {
            var product = await queryUnitOfWork.productRead.GetByIdAsync(false, id);
            if (product is null) return NotFound();
            return Ok(product);
        }

        //[HttpGet("{productName}")]
        //[ActionName("GetProductByName")]
        //public async Task<IActionResult> GetProductByName(string productName)
        //{
        //    var product = await unitOfWork.productRead.GetAsync(false, p => p.ProductName.ToLower() == productName.ToLower() || p.ProductName.ToUpper() == productName.ToUpper());
        //    if (product is null) return NotFound();
        //    return Ok(product);
        //}


        [HttpPost]
        public async Task<IActionResult> AddProduct([FromBody] CreateProductViewModel model)
        {
            var product = new Product
            {
                ProductName = model.ProductName,
                Stock = model.Stock,
                Price = model.Price
            };
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState.Values.Select(x=>x.Errors.ToArray()));
            }
            await commandUnitOfWork.productWrite.CreateAsync(product);
            await commandUnitOfWork.SaveAsync();
            return Created("", product);
        }


        [HttpPut]
        public async Task<IActionResult> UpdateProduct([FromBody] UpdateProductViewModel updateProductView)
        {
            var productExist = await queryUnitOfWork.productRead.GetAsync(true, p => p.Id == Guid.Parse(updateProductView.Id));
            if (productExist is null) return NotFound();

            if (ModelState.IsValid)
            {
                productExist.ProductName = updateProductView.ProductName;
                productExist.Stock = updateProductView.Stock;
                productExist.Price = updateProductView.Price;

                commandUnitOfWork.productWrite.Update(productExist);
                await commandUnitOfWork.SaveAsync();
                return NoContent();
            }

            return BadRequest();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProduct(string id)
        {
            var product = await queryUnitOfWork.productRead.GetByIdAsync(false, id);
            if (product == null) return NotFound();

            commandUnitOfWork.productWrite.Delete(product);
            await commandUnitOfWork.SaveAsync();
            return NoContent();
        }
    }
}

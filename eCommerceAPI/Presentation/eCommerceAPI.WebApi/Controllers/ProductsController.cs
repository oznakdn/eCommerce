using eCommerceAPI.Application.UnitOfWork;
using eCommerceAPI.Domain.Entities;
using eCommerceAPI.WebApi.ViewModels.ProductViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace eCommerceAPI.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IUnitOfWork unitOfWork;

        public ProductsController(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        [HttpPost]
        public async Task<IActionResult> AddProduct([FromBody] CreateProductViewModel model)
        {
            var product = new Product
            {
                ProductName = model.ProductName,
                Stock = model.Stock,
                Price = model.Price
            };
            await unitOfWork.productWrite.CreateAsync(product);
            //await unitOfWork.SaveAsync();
            return Created("", product);
        }

        [HttpGet]
        public async Task<IActionResult> GetProducts()
        {
            var products = unitOfWork.productRead.GetAll(false);
            var result = await products.ToListAsync();
            return Ok(result);
        }
    }
}

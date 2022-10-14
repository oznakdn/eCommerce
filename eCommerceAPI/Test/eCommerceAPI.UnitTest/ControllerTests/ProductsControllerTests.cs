using eCommerceAPI.Application.Features.Commands.ProductCommands.AddProduct;
using eCommerceAPI.Application.Features.Commands.ProductCommands.DeleteProduct;
using eCommerceAPI.Application.Features.Commands.ProductCommands.UpdateProduct;
using eCommerceAPI.Application.Features.Queries.ProductQueries.GetAllProducts;
using eCommerceAPI.Application.Features.Queries.ProductQueries.GetProductById;
using eCommerceAPI.WebApi.Controllers;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Moq;

namespace eCommerceAPI.UnitTest.ControllerTests
{
    public class ProductsControllerTests
    {

        private Mock<IMediator> _mediatorMock;
        private ProductsController _productsController;
        List<GetAllProductsQueryResponse> _products;
        GetProductByIdQueryResponse _product;

        public ProductsControllerTests()
        {
            _mediatorMock = new Mock<IMediator>();
            _productsController = new ProductsController(_mediatorMock.Object);
            _products = new List<GetAllProductsQueryResponse>
            {
                new GetAllProductsQueryResponse{Id =new Guid("20c5e7fe-f408-4ad2-9c8c-2a8ec8c2a7cc"), ProductName = "Kalem", Price=10,Stock=100, CreatedDate=DateTime.UtcNow.ToShortDateString()},
                new GetAllProductsQueryResponse{Id =new Guid("717d682d-fef2-436f-a1dc-30b0da5034ce"), ProductName = "Boya", Price=20,Stock=200, CreatedDate=DateTime.UtcNow.ToShortDateString()},
                new GetAllProductsQueryResponse{Id =new Guid("be2abacf-c25b-46d2-877f-95daface4eb4"), ProductName = "Silgi", Price=30,Stock=300, CreatedDate=DateTime.UtcNow.ToShortDateString()}

            };

            _product = new()
            {
                Id = new Guid("20c5e7fe-f408-4ad2-9c8c-2a8ec8c2a7cc"),
                ProductName = "Kalem",
                Price = 10,
                Stock = 100,
                CreatedDate = DateTime.UtcNow.ToShortDateString()
            };

        }

        [Fact]
        public async Task GetProducts_ActionMethodExecute_ReturnOkObjectResult()
        {
            _mediatorMock.Setup(x => x.Send(new GetAllProductsQueryRequest(), new CancellationToken())).ReturnsAsync(_products);
            var result = await _productsController.GetProducts();
     
            var returnType = Assert.IsType<OkObjectResult>(result);
            Assert.Equal(200, returnType.StatusCode);
            Assert.NotNull(result);
        }

        [Theory]
        [InlineData("20c5e7fe-f408-4ad2-9c8c-2a8ec8c2a7cc")]
        public async Task GetProductById_ActionMethodExecute_ReturnOkObjectResult(Guid productId)
        {
            var id = productId.ToString();
            _mediatorMock.Setup(x => x.Send(new GetProductByIdQueryRequest(id), new CancellationToken())).ReturnsAsync(_product);

            var result = await _productsController.GetProductById(id);

            var returnType = Assert.IsType<OkObjectResult>(result);
            Assert.Equal(200, returnType.StatusCode);
            Assert.NotNull(result);
        }

        [Fact]
        public async Task AddProduct_When_ModelStateInValid_ReturnBadRequestObjectResult()
        {

            _productsController.ModelState.AddModelError("", "");
            var result = await _productsController.AddProduct(new AddProductCommandRequest());
            var returnType = Assert.IsType<BadRequestObjectResult>(result);
            Assert.Equal(400, returnType.StatusCode);
        }

        [Fact]
        public async Task AddProduct_When_ModelStateIsValid_ReturnOkResult()
        {
            var commandResponse = new AddProductCommandResponse("is created successfully");
            var commandRequest = new AddProductCommandRequest();
            _mediatorMock.Setup(x => x.Send(new AddProductCommandRequest(), new CancellationToken())).ReturnsAsync(commandResponse);

            var result = await _productsController.AddProduct(commandRequest);
            var returnType = Assert.IsType<OkResult>(result);
            Assert.Equal(200, returnType.StatusCode);
        }

        [Fact]
        public async Task UpdateProduct_When_ModelStateInValid_ReturnBadRequestResult()
        {

            _productsController.ModelState.AddModelError("", "");
            var result = await _productsController.UpdateProduct(new UpdateProductCommandRequest());
            var returnType = Assert.IsType<BadRequestResult>(result);
            Assert.Equal(400, returnType.StatusCode);
        }

        [Fact]
        public async Task UpdateProduct_When_ModelStateIsValid_ReturnCreatedAtAction()
        {
            var commandResponse = new UpdateProductCommandResponse("is created successfully");
            var commandRequest = new UpdateProductCommandRequest();
            _mediatorMock.Setup(x => x.Send(new UpdateProductCommandRequest(), new CancellationToken())).ReturnsAsync(commandResponse);

            var result = await _productsController.UpdateProduct(commandRequest);
            var returnType = Assert.IsType<CreatedAtActionResult>(result);
            Assert.Equal("GetProductById", returnType.ActionName);
            Assert.Equal(commandRequest.Id, returnType.RouteValues.Select(x=>x.Value).Single());
            Assert.IsType<UpdateProductCommandRequest>(returnType.Value);
            
        }

        [Theory]
        [InlineData("20c5e7fe-f408-4ad2-9c8c-2a8ec8c2a7cc")]
        public async Task DeleteProduct_ActionMethodExecute_ReturnNoContentResul(Guid productId)
        {
            string id = productId.ToString();
            _mediatorMock.Setup(x => x.Send(new DeleteProductCommandRequest(id), new CancellationToken())).ReturnsAsync(new DeleteProductCommandResponse(""));

            var result = await _productsController.DeleteProduct(id);
            var returnResult = Assert.IsType<NoContentResult>(result);
        }


    }
}

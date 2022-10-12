namespace eCommerceAPI.Application.Features.Commands.ProductCommands.AddProduct
{
    public class AddProductCommandResponse
    {
        public AddProductCommandResponse(string message)
        {
            Message = message;
        }
        public string Message { get; set; }
    }
}

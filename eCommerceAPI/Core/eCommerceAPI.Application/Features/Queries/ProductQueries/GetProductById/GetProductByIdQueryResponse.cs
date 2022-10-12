namespace eCommerceAPI.Application.Features.Queries.ProductQueries.GetProductById
{
    public class GetProductByIdQueryResponse
    {
        public Guid Id { get; set; }
        public string ProductName { get; set; }
        public int Stock { get; set; }
        public decimal Price { get; set; }
        public string CreatedDate { get; set; }

        public string? ResponseMessage { get; set; }
    }
}

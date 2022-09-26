using eCommerceAPI.Domain.Entities.Common;

namespace eCommerceAPI.Domain.Entities
{
    public class Product:BaseEntity
    {
        public string ProductName { get; set; }
        public int Stock { get; set; }
        public decimal Price { get; set; }

        public ICollection<ProductImageFile> ProductImageFiles { get; set; }
        public ICollection<BasketItem> BasketItems { get; set; }
    }
}

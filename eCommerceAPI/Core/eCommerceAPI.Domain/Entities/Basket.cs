using eCommerceAPI.Domain.Entities.Common;
using eCommerceAPI.Domain.Entities.Identity;

namespace eCommerceAPI.Domain.Entities
{
    public class Basket:BaseEntity
    {
        public string UserId { get; set; }
        public AppUser User { get; set; }
        public Order Order { get; set; }
        public ICollection<BasketItem> BasketItems { get; set; }
    }
}

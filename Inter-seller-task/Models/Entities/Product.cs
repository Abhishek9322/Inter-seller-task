using Inter_seller_task.Models.Common;

namespace Inter_seller_task.Models.Entities
{
    public class Product : BaseEntity
    {
        public int SellerId { get; set; }

        public User Seller { get; set; } = null!;

        public string ProductName { get; set; } = string.Empty;

        public string ProductDescription { get; set; } = string.Empty;

        public ICollection<ProductBrand> Brands { get; set; }
            = new List<ProductBrand>();
    }
}

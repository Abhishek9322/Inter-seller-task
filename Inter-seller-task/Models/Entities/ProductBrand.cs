using Inter_seller_task.Models.Common;

namespace Inter_seller_task.Models.Entities
{
    public class ProductBrand : BaseEntity
    {
        public int ProductId { get; set; }

        public Product Product { get; set; } = null!;

        public string BrandName { get; set; } = string.Empty;

        public string Detail { get; set; } = string.Empty;

        public string Image { get; set; } = string.Empty;

        public decimal Price { get; set; }
    }
}

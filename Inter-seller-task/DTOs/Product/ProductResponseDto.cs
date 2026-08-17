namespace Inter_seller_task.DTOs.Product
{
    public class ProductResponseDto
    {
        public int Id { get; set; }

        public string ProductName { get; set; } = string.Empty;

        public string ProductDescription { get; set; } = string.Empty;

        public List<ProductBrandDto> Brands { get; set; } = new();

        public decimal TotalPrice { get; set; }

        public DateTime CreatedAt { get; set; }
    }
}
    
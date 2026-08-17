namespace Inter_seller_task.DTOs.Product
{
    public class CreateProductDto
    {
        public string ProductName { get; set; } = string.Empty;

        public string ProductDescription { get; set; } = string.Empty;

        public List<ProductBrandDto> Brands { get; set; } = new();
    }
}
    
using Inter_seller_task.DTOs.Product;

namespace Inter_seller_task.Services.Interfaces
{
    public interface IProductService
    {
        Task<ProductResponseDto> CreateProductAsync(CreateProductDto request,int sellerId);
    }
}

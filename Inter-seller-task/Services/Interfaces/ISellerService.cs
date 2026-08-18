using Inter_seller_task.DTOs.Seller;

namespace Inter_seller_task.Services.Interfaces
{
    public interface ISellerService
    {
        Task<SellerResponseDto> CreateSellerAsync(CreateSellerDto request);
    }
}

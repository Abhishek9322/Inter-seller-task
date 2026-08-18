using Inter_seller_task.DTOs.Common;
using Inter_seller_task.DTOs.Seller;

namespace Inter_seller_task.Services.Interfaces
{
    public interface ISellerQueryService
    {
        Task<PaginatedResponseDto<SellerResponseDto>> GetSellersAsync(int pageNumber, int pageSize);
    }
}

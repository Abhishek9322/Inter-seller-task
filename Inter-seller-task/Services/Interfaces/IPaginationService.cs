using Inter_seller_task.DTOs.Common;
using Inter_seller_task.DTOs.Seller;

namespace Inter_seller_task.Services.Interfaces
{
    public interface IPaginationService
    {
        PaginatedResponseDto<T> CreateResponse<T>(
         List<T> items,
         int pageNumber,
         int pageSize,
         int totalRecords);

        void Validate(
      int pageNumber,
      int pageSize);

    }
 }

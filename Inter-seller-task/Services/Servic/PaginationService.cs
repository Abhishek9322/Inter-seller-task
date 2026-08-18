using Inter_seller_task.DTOs.Common;
using Inter_seller_task.DTOs.Seller;
using Inter_seller_task.Services.Interfaces;

namespace Inter_seller_task.Services.Servic
{
    public class PaginationService : IPaginationService
    {
        public void Validate(
           int pageNumber,
           int pageSize)
        {
            if (pageNumber <= 0)
            {
                throw new ArgumentException(
                    "Page number must be greater than zero.");
            }

            if (pageSize <= 0)
            {
                throw new ArgumentException(
                    "Page size must be greater than zero.");
            }

            if (pageSize > 100)
            {
                throw new ArgumentException(
                    "Page size cannot be greater than 100.");
            }
        }
        public PaginatedResponseDto<T> CreateResponse<T>(
         List<T> items,
         int pageNumber,
         int pageSize,
         int totalRecords)
        {
            var totalPages = (int)Math.Ceiling(
                totalRecords / (double)pageSize);

            return new PaginatedResponseDto<T>
            {
                Items = items,
                PageNumber = pageNumber,
                PageSize = pageSize,
                TotalRecords = totalRecords,
                TotalPages = totalPages
            };
        }


       

    }
}

using AutoMapper;
using Inter_seller_task.DTOs.Common;
using Inter_seller_task.DTOs.Seller;
using Inter_seller_task.Repositories.Interfaces;
using Inter_seller_task.Services.Interfaces;

namespace Inter_seller_task.Services.Servic
{
    public class SellerQueryService : ISellerQueryService
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;
        private readonly IPaginationService _paginationService;

        public SellerQueryService(
            IUserRepository userRepository,
            IMapper mapper,
            IPaginationService paginationService)
        {
            _userRepository = userRepository;
            _mapper = mapper;
            _paginationService = paginationService;
        }
        public async Task<PaginatedResponseDto<SellerResponseDto>> GetSellersAsync(int pageNumber, int pageSize)
        {
            _paginationService.Validate(
            pageNumber,
            pageSize);

            var totalRecords =
                await _userRepository.GetSellerCountAsync();

            var skip = (pageNumber - 1) * pageSize;

            var sellers =
                await _userRepository.GetSellersAsync(
                    skip,
                    pageSize);

            var sellerDtos =
                _mapper.Map<List<SellerResponseDto>>(sellers);

            return _paginationService.CreateResponse(
                sellerDtos,
                pageNumber,
                pageSize,
                totalRecords);

        }
    }
}

using Inter_seller_task.DTOs.Seller;
using Inter_seller_task.Services.Interfaces;
using Inter_seller_task.Services.Servic;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Inter_seller_task.Controllers
{
    [Route("api/Seller/create")]
    [ApiController]
    [Authorize(Roles = "Admin")]
    public class SellerController : ControllerBase
    {
        private readonly ISellerService _sellerService;
        private readonly ISellerQueryService _sellerQueryService;
        public SellerController(ISellerService sellerService, ISellerQueryService sellerQueryService    )
        {
            _sellerService = sellerService;
            _sellerQueryService = sellerQueryService;
        }

        [HttpPost]
        public async Task<IActionResult> CreateSeller(CreateSellerDto request)
        {
            var response = await _sellerService.CreateSellerAsync(request);
            return Ok(response);
        }

        [HttpGet]
        public async Task<IActionResult> GetSellers([FromQuery] int pageNumber = 1,[FromQuery] int pageSize = 10)
        {
            var sellers =
                await _sellerQueryService.GetSellersAsync(
                    pageNumber,
                    pageSize);

            return Ok(sellers);
        }
    }

}

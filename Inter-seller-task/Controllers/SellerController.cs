using Inter_seller_task.DTOs.Seller;
using Inter_seller_task.Services.Interfaces;
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
        public SellerController(ISellerService sellerService)
        {
            _sellerService = sellerService;
        }

        [HttpPost]
        public async Task<IActionResult> CreateSeller(CreateSellerDto request)
        {
            var response = await _sellerService.CreateSellerAsync(request);
            return Ok(response);
        }

    }

}

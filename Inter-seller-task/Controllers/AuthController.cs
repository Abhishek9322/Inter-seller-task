using Inter_seller_task.DTOs.Auth;
using Inter_seller_task.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Inter_seller_task.Controllers
{
    [Route("api/Auth/Admin")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;
        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }

        [HttpPost]
        public async Task<IActionResult> AdminLogin(LoginRequestDto loginRequest)
        {
            var response=await _authService.AdminLoginAsync(loginRequest);

            return Ok(response);    
        }

        [HttpGet("test")]
        [Authorize(Roles = "Admin")]
        public IActionResult Test() 
        {
            return Ok(new 
            { message = "Admin authorization is working." }
            );
        }

        [HttpPost("SellerLogin")]
        public async Task<IActionResult> SellerLogin(LoginRequestDto request)
        {
            var response =
                await _authService.SellerLoginAsync(request);

            return Ok(response);
        }
    }
}

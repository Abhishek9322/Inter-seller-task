using Inter_seller_task.DTOs.Auth;
using Inter_seller_task.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Inter_seller_task.Controllers
{
    [Route("api/Auth")]
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
    }
}

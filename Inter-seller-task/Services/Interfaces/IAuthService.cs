using Inter_seller_task.DTOs.Auth;

namespace Inter_seller_task.Services.Interfaces
{
    public interface IAuthService
    {
        Task<LoginResponseDto> AdminLoginAsync(LoginRequestDto request);
        Task<LoginResponseDto> SellerLoginAsync(LoginRequestDto request);
    }
}

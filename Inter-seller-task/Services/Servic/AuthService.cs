using Inter_seller_task.DTOs.Auth;
using Inter_seller_task.Models.Entities;
using Inter_seller_task.Repositories.Interfaces;
using Inter_seller_task.Services.Interfaces;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Identity;

namespace Inter_seller_task.Services.Servic
{
    public class AuthService : IAuthService
    {
        private readonly IUserRepository _userRepository;
        private readonly IJwtService _jwtService;
        private readonly PasswordHasher<User> _passwordHasher;
        public AuthService(IUserRepository userRepository, IJwtService jwtService, PasswordHasher<User> passwordHasher)
        {
            _userRepository = userRepository;
            _jwtService= jwtService;    
            _passwordHasher = passwordHasher;
        }
        public Task<LoginResponseDto> AdminLoginAsync(LoginRequestDto request)
        {
            throw new NotImplementedException();
        }
    }
}

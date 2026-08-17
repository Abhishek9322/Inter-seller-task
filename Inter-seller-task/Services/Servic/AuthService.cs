using Inter_seller_task.DTOs.Auth;
using Inter_seller_task.Models.Common;
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
        public async Task<LoginResponseDto> AdminLoginAsync(LoginRequestDto request)
        {
            var user = await _userRepository.GetByEmailAsync(request.Email); 

            if (user is null)
            { 
                throw new UnauthorizedAccessException("Invalid email or password.");
            }

            if (user.Role != Role.Admin) 
            { 
                throw new UnauthorizedAccessException("Only an admin can use this login."); 
            }
            var passwordResult = _passwordHasher.VerifyHashedPassword(user, user.PasswordHash, request.Password);

            if (passwordResult == PasswordVerificationResult.Failed) 
            { 
                throw new UnauthorizedAccessException("Invalid email or password."); 
            }
            var accessToken = _jwtService.GenerateToken(user); 
            
            return new LoginResponseDto 
            {
                AccessToken = accessToken,
                //Role = user.Role.ToString()
            };
        }
    }
    
}

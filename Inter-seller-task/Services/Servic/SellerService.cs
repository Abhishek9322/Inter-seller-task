using AutoMapper;
using Inter_seller_task.DTOs.Seller;
using Inter_seller_task.Models.Common;
using Inter_seller_task.Models.Entities;
using Inter_seller_task.Repositories.Interfaces;
using Inter_seller_task.Services.Interfaces;
using Microsoft.AspNetCore.Identity;

namespace Inter_seller_task.Services.Servic
{
    public class SellerService : ISellerService
    {
        private readonly IUserRepository _userRepository;
        private readonly ISkillRepository _skillRepository;
        private readonly PasswordHasher<User> _passwordHasher;
        private readonly IMapper _mapper;
        public SellerService(
                              IUserRepository userRepository,
                             ISkillRepository skillRepository,
                             PasswordHasher<User> passwordHasher,
                              IMapper mapper)
        {
            _userRepository = userRepository;
            _skillRepository = skillRepository;
            _passwordHasher = passwordHasher;
            _mapper = mapper;
        }
        public async Task<SellerResponseDto> CreateSellerAsync(CreateSellerDto request)
        {

            var existingUser = await _userRepository.GetByEmailAsync(request.Email);

            if (existingUser !=null)
            {
                throw new InvalidOperationException(
                    "A user with this email already exists.");
            }

            if (request.SkillIds ==null ||
                request.SkillIds.Count == 0)
            {
                throw new ArgumentException(
                    "At least one skill is required.");
            }

            var skillsExist = await _skillRepository.AllExistAsync(request.SkillIds);

            if (!skillsExist)
            {
                throw new ArgumentException(
                    "One or more selected skills do not exist.");
            }

            var seller = _mapper.Map<User>(request);

            seller.Role = Role.Seller;

            seller.PasswordHash = _passwordHasher
                .HashPassword(
                    seller,
                    request.Password);

            foreach (var skillId in request.SkillIds.Distinct())
            {
                seller.SellerSkills.Add(
                    new SellerSkill
                    {
                        SkillId = skillId
                    });
            }

            await _userRepository.AddAsync(seller);

            await _userRepository.SaveChangesAsync();

            var createdSeller = await _userRepository.GetByIdWithSkillsAsync(seller.Id);

            if (createdSeller ==null)
            {
                throw new InvalidOperationException(
                    "Seller could not be retrieved after creation.");
            }

            return _mapper.Map<SellerResponseDto>(
                createdSeller);
        }
    }
    
}

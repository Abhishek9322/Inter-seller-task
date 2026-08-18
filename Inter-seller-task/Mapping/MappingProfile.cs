using AutoMapper;
using Inter_seller_task.DTOs.Seller;
using Inter_seller_task.Models.Entities;

namespace Inter_seller_task.Mapping
{
    public class MappingProfile:Profile
    {
        public MappingProfile()
        {
            CreateMap<CreateSellerDto, User>()
                .ForMember(dest => dest.PasswordHash, opt => opt.Ignore())
                .ForMember(dest => dest.Role, opt => opt.Ignore())
                .ForMember(dest => dest.SellerSkills, opt => opt.Ignore());

            CreateMap<User, SellerResponseDto>()
                .ForMember(dest => dest.Skills, opt => opt
                .MapFrom(src => src.SellerSkills.Select(x => x.Skill.Name)
                .ToList()));
        }
    }
}

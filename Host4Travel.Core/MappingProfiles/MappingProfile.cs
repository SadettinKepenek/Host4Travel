using AutoMapper;
using Host4Travel.Core.DTO.CategoryService;
using Host4Travel.Core.DTO.RewardService;
using Host4Travel.UI;

namespace Host4Travel.Core.MappingProfiles
{
    public class MappingProfile:Profile
    {
        public MappingProfile() {
            // Add as many of these lines as you need to map your objects
            CreateMap<Category, CategoryListDto>().ReverseMap();
            CreateMap<CategoryAddDto, Category>();
            CreateMap<CategoryUpdateDto, Category>();
            CreateMap<CategoryDeleteDto, Category>();

            CreateMap<Reward, RewardGetAllDto>().ReverseMap();
            CreateMap<RewardAddDto, Reward>();
            CreateMap<RewardUpdateDto, Reward>();
            CreateMap<RewardDeleteDto, Reward>();

        }
    }
}
using AutoMapper;
using Host4Travel.Core.DTO.CategoryRewardService;
using Host4Travel.Core.DTO.CategoryService;
using Host4Travel.Core.DTO.RewardService;
using Host4Travel.Entities.Concrete;
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

            CreateMap<Reward, RewardListDto>().ReverseMap();
            CreateMap<RewardAddDto, Reward>();
            CreateMap<RewardUpdateDto, Reward>();
            CreateMap<RewardDeleteDto, Reward>();
            
            CreateMap<CategoryReward, CategoryRewardListDto>().ReverseMap();
            CreateMap<CategoryRewardAddDto,CategoryReward>();
            CreateMap<CategoryRewardUpdateDto,CategoryReward>();
            CreateMap<CategoryRewardDeleteDto,CategoryReward>();
            
        }
    }
}
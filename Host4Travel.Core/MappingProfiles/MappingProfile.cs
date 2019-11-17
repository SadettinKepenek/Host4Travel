using AutoMapper;
using Host4Travel.Core.DTO.CategoryRewardService;
using Host4Travel.Core.DTO.CategoryService;
using Host4Travel.Core.DTO.PostApplicationService;
using Host4Travel.Core.DTO.PostCategoryRewardService;
using Host4Travel.Core.DTO.PostCheckInService;
using Host4Travel.Core.DTO.PostDiscussionService;
using Host4Travel.Core.DTO.PostImageService;
using Host4Travel.Core.DTO.PostRatingService;
using Host4Travel.Core.DTO.PostService;
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
            
            CreateMap<PostApplication, PostApplicationListDto>().ReverseMap();
            CreateMap<PostApplicationAddDto,PostApplication>();
            CreateMap<PostApplicationUpdateDto,PostApplication>();
            CreateMap<PostApplicationDeleteDto,PostApplication>();
            
            CreateMap<PostCategoryReward, PostCategoryRewardListDto>().ReverseMap();
            CreateMap<PostCategoryRewardAddDto,PostCategoryReward>();
            CreateMap<PostCategoryRewardUpdateDto,PostCategoryReward>();
            CreateMap<PostCategoryRewardDeleteDto,PostCategoryReward>();
            
            CreateMap<PostCheckIn, PostCheckInListDto>().ReverseMap();
            CreateMap<PostCheckInAddDto,PostCheckIn>();
            CreateMap<PostCheckInUpdateDto,PostCheckIn>();
            CreateMap<PostCheckInDeleteDto,PostCheckIn>();
            
            CreateMap<PostDiscussion, PostDiscussionListDto>().ReverseMap();
            CreateMap<PostDiscussionAddDto,PostDiscussion>();
            CreateMap<PostDiscussionUpdateDto,PostDiscussion>();
            CreateMap<PostDiscussionDeleteDto,PostDiscussion>();
            
            CreateMap<PostImage, PostImageListDto>().ReverseMap();
            CreateMap<PostImageAddDto,PostImage>();
            CreateMap<PostImageUpdateDto,PostImage>();
            CreateMap<PostImageDeleteDto,PostImage>();
            
            CreateMap<PostRating, PostRatingListDto>().ReverseMap();
            CreateMap<PostRatingAddDto,PostRating>();
            CreateMap<PostRatingUpdateDto,PostRating>();
            CreateMap<PostRatingDeleteDto,PostRating>();
            
            CreateMap<Post, PostListDto>().ReverseMap();
            CreateMap<Post, PostDetailDto>().ReverseMap();
            CreateMap<PostAddDto,Post>();
            CreateMap<PostUpdateDto,Post>();
            CreateMap<PostDiscussionDeleteDto,Post>();
        }
    }
}
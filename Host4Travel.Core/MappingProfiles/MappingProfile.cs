using AutoMapper;
using Host4Travel.Core.DTO.AuthService;
using Host4Travel.Core.DTO.CategoryDtos;
using Host4Travel.Core.DTO.CategoryRewardDtos;
using Host4Travel.Core.DTO.DocumentDtos;
using Host4Travel.Core.DTO.DocumentTypeDtos;
using Host4Travel.Core.DTO.PostApplicationDtos;
using Host4Travel.Core.DTO.PostCategoryRewardDtos;
using Host4Travel.Core.DTO.PostCheckInDtos;
using Host4Travel.Core.DTO.PostDiscussionDtos;
using Host4Travel.Core.DTO.PostDtos;
using Host4Travel.Core.DTO.PostImageDtos;
using Host4Travel.Core.DTO.PostRatingDtos;
using Host4Travel.Core.DTO.RewardDtos;
using Host4Travel.Core.DTO.UserDtos;
using Host4Travel.Entities.Concrete;
using Host4Travel.UI;

namespace Host4Travel.Core.MappingProfiles
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            // Add as many of these lines as you need to map your objects
            CreateMap<Category, CategoryDetailDto>().ReverseMap();
            CreateMap<Category, CategoryListDto>()
                .ForMember(c => c.CategoryParentName, opt => opt.MapFrom(c => c.CategoryParent.CategoryName))
                .ForMember(c=>c.CategoryParentId,opt=>opt.MapFrom(c=>c.CategoryParentId))
                .ReverseMap();
            CreateMap<CategoryAddDto, Category>();
            CreateMap<CategoryUpdateDto, Category>();
            CreateMap<CategoryDeleteDto, Category>();

            CreateMap<Reward, RewardDetailDto>().ReverseMap();
            CreateMap<RewardAddDto, Reward>();
            CreateMap<RewardUpdateDto, Reward>();
            CreateMap<RewardDeleteDto, Reward>();

            CreateMap<CategoryReward, CategoryRewardDetailDto>().ReverseMap();
            CreateMap<CategoryReward, CategoryRewardListDto>()
                .ForMember(x=>x.CategoryName,c=>c.MapFrom(d=>d.Category.CategoryName))
                .ForMember(x=>x.RewardName,c=>c.MapFrom(d=>d.Reward.RewardName))
                .ReverseMap();
            CreateMap<CategoryRewardAddDto, CategoryReward>();
            CreateMap<CategoryRewardUpdateDto, CategoryReward>();
            CreateMap<CategoryRewardDeleteDto, CategoryReward>();

            CreateMap<PostApplication, PostApplicationDetailDto>().ReverseMap();
            CreateMap<PostApplicationAddDto, PostApplication>();
            CreateMap<PostApplicationUpdateDto, PostApplication>();
            CreateMap<PostApplicationDeleteDto, PostApplication>();

            CreateMap<PostCategoryReward, PostCategoryRewardDetailDto>().ReverseMap();
            CreateMap<PostCategoryRewardAddDto, PostCategoryReward>();
            CreateMap<PostCategoryRewardDeleteDto, PostCategoryReward>();

            CreateMap<PostCheckIn, PostCheckInDetailDto>().ReverseMap();
            CreateMap<PostCheckInAddDto, PostCheckIn>();
            CreateMap<PostCheckInUpdateDto, PostCheckIn>();
            CreateMap<PostCheckInDeleteDto, PostCheckIn>();

            CreateMap<PostDiscussion, PostDiscussionDetailDto>().ReverseMap();
            CreateMap<PostDiscussionAddDto, PostDiscussion>();
            CreateMap<PostDiscussionUpdateDto, PostDiscussion>();
            CreateMap<PostDiscussionDeleteDto, PostDiscussion>();

            CreateMap<PostImage, PostImageDetailDto>().ReverseMap();
            CreateMap<PostImageAddDto, PostImage>();
            CreateMap<PostImageDeleteDto, PostImage>();

            CreateMap<PostRating, PostRatingDetailDto>().ReverseMap();
            CreateMap<PostRatingAddDto, PostRating>();
            CreateMap<PostRatingUpdateDto, PostRating>();
            CreateMap<PostRatingDeleteDto, PostRating>();

            CreateMap<Post, PostListDto>().ReverseMap();
            CreateMap<Post, PostDetailDto>().ReverseMap();
            CreateMap<PostAddDto, Post>();
            CreateMap<PostUpdateDto, Post>();
            CreateMap<PostDiscussionDeleteDto, Post>();


            CreateMap<Document, DocumentDetailDto>().ReverseMap();
            CreateMap<DocumentAddDto, Document>();
            CreateMap<DocumentUpdateDto, Document>();
            CreateMap<DocumentDeleteDto, Document>();

            CreateMap<DocumentType, DocumentTypeDetailDto>().ReverseMap();
            CreateMap<DocumentTypeAddDto, DocumentType>();
            CreateMap<DocumentTypeUpdateDto, DocumentType>();
            CreateMap<DocumentTypeDeleteDto, DocumentType>();

            CreateMap<ApplicationIdentityUser, UserDetailDto>().ReverseMap();
            CreateMap<ApplicationIdentityUser, UserProfileDto>().ReverseMap();
            CreateMap<UserAddDto, ApplicationIdentityUser>();
            CreateMap<UserUpdateDto, ApplicationIdentityUser>();
            CreateMap<UserDeleteDto, ApplicationIdentityUser>();
        }
    }
}
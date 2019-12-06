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
                .ForMember(c => c.CategoryParentId, opt => opt.MapFrom(c => c.CategoryParentId))
                .ReverseMap();
            CreateMap<CategoryAddDto, Category>();
            CreateMap<CategoryUpdateDto, Category>();
            CreateMap<CategoryDeleteDto, Category>();

            CreateMap<Reward, RewardDetailDto>().ReverseMap();
            CreateMap<Reward, RewardListDto>().ReverseMap();

            CreateMap<RewardAddDto, Reward>();
            CreateMap<RewardUpdateDto, Reward>();
            CreateMap<RewardDeleteDto, Reward>();

            CreateMap<CategoryReward, CategoryRewardDetailDto>().ReverseMap();
            CreateMap<CategoryReward, CategoryRewardListDto>()
                .ForMember(x => x.CategoryName, c => c.MapFrom(d => d.Category.CategoryName))
                .ForMember(x => x.RewardName, c => c.MapFrom(d => d.Reward.RewardName))
                .ReverseMap();
            CreateMap<CategoryRewardAddDto, CategoryReward>();
            CreateMap<CategoryRewardUpdateDto, CategoryReward>();
            CreateMap<CategoryRewardDeleteDto, CategoryReward>();

            CreateMap<PostApplication, PostApplicationDetailDto>().ReverseMap();
            CreateMap<PostApplication, PostApplicationListDto>()
                .ForMember(x=> x.UserId,c =>c.MapFrom(d => d.Applicent.Id))
                .ForMember(x=> x.UserName,c =>c.MapFrom(d => d.Applicent.UserName))
                .ForMember(x=> x.Firstname,c =>c.MapFrom(d => d.Applicent.Firstname))
                .ForMember(x=> x.Lastname,c =>c.MapFrom(d => d.Applicent.Lastname))
                .ForMember(x=> x.Email,c =>c.MapFrom(d => d.Applicent.Email))
                .ForMember(x=> x.UserId,c =>c.MapFrom(d => d.Applicent.Id))
                .ForMember(x=> x.PostTitle,c =>c.MapFrom(d => d.Post.PostTitle))
                .ForMember(x=> x.PostDescription,c =>c.MapFrom(d => d.Post.PostDescription))
                .ReverseMap();

            CreateMap<PostApplicationAddDto, PostApplication>();
            CreateMap<PostApplicationUpdateDto, PostApplication>();
            CreateMap<PostApplicationDeleteDto, PostApplication>();

            CreateMap<PostCategoryReward, PostCategoryRewardDetailDto>().ReverseMap();
            CreateMap<PostCategoryReward, PostCategoryRewardListDto>()
                .ForMember(x => x.CategoryName, c => c.MapFrom(d => d.Category.CategoryName))
                .ForMember(x => x.RewardName, c => c.MapFrom(d => d.Reward.RewardName))
                
                .ReverseMap();
            CreateMap<PostCategoryRewardAddDto, PostCategoryReward>();
            CreateMap<PostCategoryRewardDeleteDto, PostCategoryReward>();

            CreateMap<PostCheckIn, PostCheckInDetailDto>().ReverseMap();
            CreateMap<PostCheckIn, PostCheckInListDto>()
                .ForMember(c => c.OwnerId, d => d.MapFrom(c => c.Application.ApplicentId))
                .ForMember(c => c.OwnerEmail, d => d.MapFrom(c => c.Application.Applicent.Email))
                .ForMember(c => c.OwnerUserName, d => d.MapFrom(c => c.Application.Applicent.UserName))
                .ForMember(c => c.OwnerFirstname, d => d.MapFrom(c => c.Application.Applicent.Firstname))
                .ForMember(c => c.OwnerLastname, d => d.MapFrom(c => c.Application.Applicent.Lastname))
                .ForMember(c => c.PostDescription, d => d.MapFrom(c => c.Post.PostDescription))
                .ForMember(c => c.PostTitle, d => d.MapFrom(c => c.Post.PostTitle))
                .ForMember(c => c.PostType, d => d.MapFrom(c => c.Post.PostType))
                .ForMember(c => c.ApplicationDate, d => d.MapFrom(c => c.Application.ApplicationDate))
                .ForMember(c => c.ApplicationStartDate, d => d.MapFrom(c => c.Application.ApplicationStartDate))
                .ForMember(c => c.ApplicationEndDate, d => d.MapFrom(c => c.Application.ApplicationEndDate))
                .ForMember(c => c.ApplicationId, d => d.MapFrom(c => c.Application.PostApplicationId))
                .ForMember(c => c.PostId, d => d.MapFrom(c => c.Post.PostId))
                .ReverseMap();
            CreateMap<PostCheckInAddDto, PostCheckIn>();
            CreateMap<PostCheckInUpdateDto, PostCheckIn>();
            CreateMap<PostCheckInDeleteDto, PostCheckIn>();

            CreateMap<PostDiscussion, PostDiscussionDetailDto>().ReverseMap();
            CreateMap<PostDiscussion, PostDiscussionListDto>()
                .ForMember(x => x.PostDiscussionParentId,c => c.MapFrom(d => d.CommentNavigation.PostDiscussionId))
                .ForMember(x=> x.OwnerFirstname,c =>c.MapFrom(d => d.Owner.Firstname))
                .ForMember(x=> x.OwnerLastname,c =>c.MapFrom(d => d.Owner.Lastname))
                .ForMember(x=> x.OwnerId,c =>c.MapFrom(d => d.Owner.Id))
                .ForMember(x=> x.OwnerEmail,c =>c.MapFrom(d => d.Owner.Email))
                .ForMember(c => c.PostTitle, d => d.MapFrom(c => c.Post.PostTitle))
                .ForMember(c => c.PostDescription, d => d.MapFrom(c => c.Post.PostDescription))
                .ForMember(c => c.ParentOwnerId, d => d.MapFrom(c => c.CommentNavigation.OwnerId))
                .ForMember(c => c.ParentComment, d => d.MapFrom(c => c.CommentNavigation.Comment))
                .ReverseMap();

            CreateMap<PostDiscussionAddDto, PostDiscussion>();
            CreateMap<PostDiscussionUpdateDto, PostDiscussion>();
            CreateMap<PostDiscussionDeleteDto, PostDiscussion>();

            CreateMap<PostImage, PostImageDetailDto>().ReverseMap();
            CreateMap<PostImage, PostImageListDto>()
                .ForMember(x => x.PostTitle, d => d.MapFrom(c => c.Post.PostTitle))
                .ForMember(x => x.PostDescription, d => d.MapFrom(c => c.Post.PostDescription))
                .ReverseMap();
            CreateMap<PostImageAddDto, PostImage>();
            CreateMap<PostImageDeleteDto, PostImage>();

            CreateMap<PostRating, PostRatingDetailDto>().ReverseMap();
            CreateMap<PostRating, PostRatingListDto>()
                .ForMember(x => x.PostApplicationId,c => c.MapFrom(d => d.ApplicationId))
                .ForMember(x => x.Username,c => c.MapFrom(d=> d.Owner.UserName))
                .ForMember(x=> x.Username,c =>c.MapFrom(d => d.Application.Applicent.UserName))
                .ForMember(x=> x.Firstname,c =>c.MapFrom(d => d.Application.Applicent.Firstname))
                .ForMember(x=> x.Lastname,c =>c.MapFrom(d => d.Application.Applicent.Lastname))
                .ForMember(x=> x.Email,c =>c.MapFrom(d => d.Application.Applicent.Email))
                .ForMember(x=> x.UserId,c =>c.MapFrom(d => d.Application.Applicent.Id))
                .ForMember(x=> x.PostTitle,c =>c.MapFrom(d => d.Post.PostTitle))
                .ForMember(x=> x.PostDescription,c =>c.MapFrom(d => d.Post.PostDescription))
                
                .ReverseMap();

            CreateMap<PostRatingAddDto, PostRating>();
            CreateMap<PostRatingUpdateDto, PostRating>();
            CreateMap<PostRatingDeleteDto, PostRating>();

            CreateMap<Post, PostListDto>().ReverseMap();
            CreateMap<Post, PostDetailDto>().ReverseMap();
            CreateMap<PostAddDto, Post>();
            CreateMap<PostUpdateDto, Post>();
            CreateMap<PostDiscussionDeleteDto, Post>();


            CreateMap<Document, DocumentDetailDto>().ReverseMap();
            CreateMap<Document, DocumentListDto>()
                .ForMember(x => x.OwnerId, c => c.MapFrom(d => d.Owner.Id))
                .ForMember(x => x.OwnerName, c => c.MapFrom(d => d.Owner.Firstname))
                .ForMember(x => x.OwnerSurname, c => c.MapFrom(d => d.Owner.Lastname))
                .ForMember(x => x.OwnerUserName, c => c.MapFrom(d => d.Owner.UserName))
                .ForMember(x => x.DocumentTypeId, c => c.MapFrom(d => d.DocumentTypeId))
                .ForMember(x => x.DocumentTypeName, c => c.MapFrom(d => d.DocumentType.DocumentTypeName))
                .ReverseMap();
            CreateMap<DocumentAddDto, Document>();
            CreateMap<DocumentUpdateDto, Document>();
            CreateMap<DocumentDeleteDto, Document>();

            CreateMap<DocumentType, DocumentTypeDetailDto>().ReverseMap();
            CreateMap<DocumentTypeAddDto, DocumentType>();
            CreateMap<DocumentTypeUpdateDto, DocumentType>();
            CreateMap<DocumentTypeDeleteDto, DocumentType>();

            CreateMap<ApplicationIdentityUser, UserDetailDto>().ReverseMap();
            CreateMap<ApplicationIdentityUser, UserListDto>().ReverseMap();
            CreateMap<ApplicationIdentityUser, UserProfileDto>().ReverseMap();
            CreateMap<UserAddDto, ApplicationIdentityUser>();
            CreateMap<UserUpdateDto, ApplicationIdentityUser>();
            CreateMap<UserDeleteDto, ApplicationIdentityUser>();
        }
    }
}
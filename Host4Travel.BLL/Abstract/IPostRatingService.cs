using System;
using System.Collections.Generic;
using Host4Travel.Core.DTO.PostRatingDtos;
using Host4Travel.UI;

namespace Host4Travel.BLL.Abstract
{
    public interface IPostRatingService
    {
        List<PostRatingListDto> GetAllRatings();
        PostRatingDetailDto GetById(Guid ratingId);

        List<PostRatingListDto> GetUsersRatings(string id);

        List<PostRatingListDto> GetMyPostRatings(string userId);
        void AddRating(PostRatingAddDto dto);
        void UpdateRating(PostRatingUpdateDto dto);
        void DeleteRating(PostRatingDeleteDto dto);
    }
}
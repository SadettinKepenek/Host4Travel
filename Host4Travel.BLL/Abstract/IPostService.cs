using System;
using System.Collections.Generic;
using Host4Travel.Core.DTO.PostDtos;
using Host4Travel.UI;

namespace Host4Travel.BLL.Abstract
{
    public interface IPostService
    {
        List<PostListDto> GetAllPosts();
        PostDetailDto GetPost(Guid postId);
        List<PostListDto> GetByUser(string userId);
        void AddPost(PostAddDto model);
        void UpdatePost(PostUpdateDto model);
        void DeletePost(PostDeleteDto model);
        
    }
}
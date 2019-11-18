using System;
using System.Collections.Generic;
using Host4Travel.Core.DTO.PostImageService;
using Host4Travel.UI;

namespace Host4Travel.BLL.Abstract
{
    public interface IPostImageService
    {
        List<PostImageListDto> GetAllImages();
        PostImageListDto GetImageById(Guid id);
        void AddImage(PostImageAddDto dto);
        void UpdateImage(PostImageAddDto dto);
        void DeleteImage(PostImageDeleteDto dto);
    }
}
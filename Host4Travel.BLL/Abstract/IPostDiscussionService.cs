using System;
using System.Collections.Generic;
using Host4Travel.Core.DTO.PostDiscussionDtos;
using Host4Travel.UI;

namespace Host4Travel.BLL.Abstract
{
    public interface IPostDiscussionService
    {
        List<PostDiscussionDetailDto> GetAll();
        PostDiscussionDetailDto GetById(Guid id);
        void Add(PostDiscussionAddDto dto);
        void Update(PostDiscussionUpdateDto dto);
        void Delete(PostDiscussionDeleteDto dto);

    }
}
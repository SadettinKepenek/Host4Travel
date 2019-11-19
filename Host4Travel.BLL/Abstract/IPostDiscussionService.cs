﻿using System;
using System.Collections.Generic;
using Host4Travel.Core.DTO.PostDiscussionService;
using Host4Travel.UI;

namespace Host4Travel.BLL.Abstract
{
    public interface IPostDiscussionService
    {
        List<PostDiscussionListDto> GetAll();
        PostDiscussionListDto GetById(Guid id);
        void Add(PostDiscussionAddDto dto);
        void Update(PostDiscussionUpdateDto dto);
        void Delete(PostDiscussionDeleteDto dto);

    }
}
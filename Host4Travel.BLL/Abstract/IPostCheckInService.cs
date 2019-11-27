using System;
using System.Collections.Generic;
using Host4Travel.Core.DTO.PostCheckInDtos;
using Host4Travel.UI;

namespace Host4Travel.BLL.Abstract
{
    public interface IPostCheckInService
    {
        List<PostCheckInListDto> GetAll();
        PostCheckInDetailDto GetById(Guid id);
        void Add(PostCheckInAddDto model);
        void Update(PostCheckInUpdateDto model);
        void Delete(PostCheckInDeleteDto model);
    }
}
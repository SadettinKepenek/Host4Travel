using System;
using System.Collections.Generic;
using Host4Travel.Core.DTO.PostApplicationDtos;
using Host4Travel.UI;

namespace Host4Travel.BLL.Abstract
{
    public interface IPostApplicationService
    {
        List<PostApplicationDetailDto> GetAllApplications();
        PostApplicationDetailDto GetApplicationById(Guid id);
        void AddApplication(PostApplicationAddDto dto);
        void UpdateApplication(PostApplicationUpdateDto dto);
        void DeleteApplication(PostApplicationDeleteDto dto);
    }
}
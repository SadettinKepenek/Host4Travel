using System.Net;
using Host4Travel.Core.DTO.AuthService;
using Host4Travel.Entities.Concrete;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Host4Travel.BLL.Abstract
{
    public interface IAuthService
    {
        IdentityLoginResponseDto Login(IdentityLoginRequestDto model);
        bool CheckTokenExpiration();

        void Register(ApplicationIdentityUserAddDto applicationIdentityUserAddModel, string password);

        void Update(ApplicationIdentityUserUpdateDto applicationIdentityUserUpdateModel, string password);
        void Delete(ApplicationIdentityUserDeleteDto dto);


    }
}
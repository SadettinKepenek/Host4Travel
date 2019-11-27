using System.Net;
using Host4Travel.Core.DTO.AuthService;
using Host4Travel.Core.DTO.UserDtos;
using Host4Travel.Entities.Concrete;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Host4Travel.BLL.Abstract
{
    public interface IAuthService
    {
        LoginResponseDto Login(LoginRequestDto model);
        bool CheckTokenExpiration();

        void Register(UserAddDto userAddModel, string password);

        void Update(UserUpdateDto userUpdateModel, string password);
        void Delete(UserDeleteDto dto);
        UserListDto GetUser();
        UserDetailDto GetUserDetail(string userId);


    }
}
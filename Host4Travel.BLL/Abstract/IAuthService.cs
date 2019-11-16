using System.Net;
using Host4Travel.Core.DTO.AuthService;
using Host4Travel.Entities.Concrete;
using Host4Travel.UI.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Host4Travel.BLL.Abstract
{
    public interface IAuthService
    {
        LoginResponseDto Login(LoginRequestDto model);
        bool CheckTokenExpiration(string exprationTime);

        void Register(RegisterDto registerModel, string password);

        void Update(UpdateDto updateModel, string password);
        void Delete(DeleteDto dto);


    }
}
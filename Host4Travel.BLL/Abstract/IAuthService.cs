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
        LoginDto Login(ApplicationIdentityUser userParam, string password);
        StatusCodeResult CheckTokenExpiration(string exprationTime);
        bool MatchPasswordAndHash(ApplicationIdentityUser user,string password);
        GenerateTokenDto GenerateToken(ApplicationIdentityUser user);

        RegisterDto Register(ApplicationIdentityUser registerModel, string password);

        UpdateDto Update(ApplicationIdentityUser updateModel, string password);
        DeleteDto Delete(string userId);


    }
}
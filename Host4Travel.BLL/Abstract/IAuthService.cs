using System.Net;
using Host4Travel.Core.BLL.Concrete.AuthService;
using Host4Travel.Entities.Concrete;
using Host4Travel.UI.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Host4Travel.BLL.Abstract
{
    public interface IAuthService
    {
        AuthenticateModel Login(UsersLoginModel user);
        StatusCodeResult CheckTokenExpiration(string exprationTime);
        bool MatchPasswordAndHash(ApplicationIdentityUser user,string password);
        GenerateTokenModel GenerateToken(ApplicationIdentityUser user);

        RegisterModel Register(UsersRegisterModel registerModel);
        


    }
}
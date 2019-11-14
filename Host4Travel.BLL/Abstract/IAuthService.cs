using System.Net;
using Host4Travel.Core.BLL.Concrete.AuthService;
using Host4Travel.Core.BLL.Concrete.Services.AuthService;
using Host4Travel.Entities.Concrete;
using Host4Travel.UI.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Host4Travel.BLL.Abstract
{
    public interface IAuthService
    {
        LoginModel Login(ApplicationIdentityUser userParam, string password);
        StatusCodeResult CheckTokenExpiration(string exprationTime);
        bool MatchPasswordAndHash(ApplicationIdentityUser user,string password);
        GenerateTokenModel GenerateToken(ApplicationIdentityUser user);

        RegisterModel Register(ApplicationIdentityUser registerModel, string password);

        UpdateModel Update(ApplicationIdentityUser updateModel, string password);
        DeleteModel Delete(string userId);


    }
}
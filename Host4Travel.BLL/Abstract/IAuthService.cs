using Host4Travel.Core.BLL.Concrete.AuthService;
using Host4Travel.Entities.Concrete;
using Host4Travel.UI.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Host4Travel.BLL.Abstract
{
    public interface IAuthService
    {
        AuthenticateModel Authenticate(User user);
        StatusCodeResult CheckTokenExpiration();
        bool CheckUserIsValid(User user,ApplicationIdentityUser identityUser);
        AuthenticateModel GenerateToken(ApplicationIdentityUser user);
    }
}
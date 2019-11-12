using Host4Travel.UI.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Host4Travel.BLL.Abstract
{
    public interface IAuthService
    {
        string GenerateToken(ApplicationIdentityUser user);
        StatusCodeResult CheckTokenExpiration();
    }
}
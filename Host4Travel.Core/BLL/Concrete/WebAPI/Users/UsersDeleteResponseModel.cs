using System.Net;

namespace Host4Travel.Core.BLL.Concrete.WebAPI.Users
{
    public class UsersDeleteResponseModel
    {
        public string Message { get; set; }
        public HttpStatusCode StatusCode { get; set; }
    }
}
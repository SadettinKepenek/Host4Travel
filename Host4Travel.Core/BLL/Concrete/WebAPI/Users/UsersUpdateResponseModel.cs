using System.Net;

namespace Host4Travel.Core.BLL.Concrete.WebAPI.Users
{
    public class UsersUpdateResponseModel
    {
        public HttpStatusCode StatusCode { get; set; }
        public string Message { get; set; }
    }
}
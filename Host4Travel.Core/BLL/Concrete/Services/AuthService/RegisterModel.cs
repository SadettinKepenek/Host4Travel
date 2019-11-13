using System.Net;

namespace Host4Travel.Core.BLL.Concrete.AuthService
{
    public class RegisterModel
    {
        public HttpStatusCode StatusCode { get; set; }
        public string Message { get; set; }
    }
}
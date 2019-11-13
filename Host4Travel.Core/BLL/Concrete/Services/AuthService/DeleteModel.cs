using System.Net;

namespace Host4Travel.Core.BLL.Concrete.Services.AuthService
{
    public class DeleteModel
    {
        public HttpStatusCode StatusCode { get; set; }
        public string Message { get; set; }
    }
}
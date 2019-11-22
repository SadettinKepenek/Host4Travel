using System.Net;

namespace Host4Travel.API.Models.Abstract
{
    public class ResponseModelBase
    {
        public string Message { get; set; }
        public HttpStatusCode StatusCode { get; set; }
    }
}
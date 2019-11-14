using System.Net;

namespace Host4Travel.API.Models.Abstract
{
    public class HttpResponseModel
    {
        public HttpStatusCode HttpStatusCode { get; set; }
        public string ResponseMessage { get; set; }
    }
}
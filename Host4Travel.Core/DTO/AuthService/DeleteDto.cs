using System.Net;

namespace Host4Travel.Core.DTO.AuthService
{
    public class DeleteDto
    {
        public HttpStatusCode StatusCode { get; set; }
        public string Message { get; set; }
    }
}
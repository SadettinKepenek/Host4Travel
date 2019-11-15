using System.Net;

namespace Host4Travel.Core.DTO.AuthService
{
    public class UpdateDto
    {
        public HttpStatusCode StatusCode { get; set; }
        public string Message { get; set; }
    }
}
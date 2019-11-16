namespace Host4Travel.Core.DTO.AuthService
{
    public class UpdateDto
    {
        public string UserId { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public string Ssn { get; set; }
        public string CookieAcceptIpAddress { get; set; }
        public string Email { get; set; }
    }
}
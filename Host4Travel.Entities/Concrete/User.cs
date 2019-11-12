namespace Host4Travel.Entities.Concrete
{
    public class User
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Token { get; set; }
        public string Email { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public string SSN { get; set; }
        public string CookieAcceptIpAddress { get; set; }
    }
}
namespace Host4Travel.Core.BLL.Concrete.AuthService
{
    public class UsersRegisterModel
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public string Ssn { get; set; }
        public string CookieAcceptIpAddress { get; set; }
        public string Email { get; set; }
    }
}
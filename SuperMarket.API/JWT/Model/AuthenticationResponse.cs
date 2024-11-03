namespace SuperMarket.API.JWT.Model
{
    public class AuthenticationResponse
    {
        public long ID { get; set; }
        public string JwtToken { get; set; }
        public string RefreshToken { get; set; }
        public string Name { get; set; }
        public string Role { get; set; }
        public string? Fullname { get; set; }
        public string? Permissions { get; set; }

    }
}

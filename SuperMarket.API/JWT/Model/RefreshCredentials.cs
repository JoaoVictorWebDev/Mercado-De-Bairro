namespace SuperMarket.API.JWT.Model
{
    public class RefreshCredentials
    {
        public string JwtToken { get; set; }
        public string RefreshToken { get; set; }
    }
}

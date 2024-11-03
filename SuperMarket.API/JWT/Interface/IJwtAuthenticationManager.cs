using SuperMarket.API.JWT.Model;
using SuperMarket.Core.Entities;
using System.Security.Claims;

namespace SuperMarket.API.JWT.Interface
{
    public interface IJwtAuthenticationManager
    {
        AuthenticationResponse Authenticate(User user);
        IDictionary<string, string> UsersRefreshTokens { get; set; }
        AuthenticationResponse Authenticate(string username, Claim[] claims);
    }
}

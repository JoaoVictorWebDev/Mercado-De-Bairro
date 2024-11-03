using Microsoft.IdentityModel.Tokens;
using SuperMarket.API.JWT.Interface;
using SuperMarket.API.JWT.Model;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;

namespace SuperMarket.API.JWT.Config
{
    public class TokenRefresher : ITokenRefresh
    {
        private readonly byte[] key;
        private readonly IJwtAuthenticationManager jWTAuthenticationManager;

        public TokenRefresher(byte[] key, IJwtAuthenticationManager jWTAuthenticationManager)
        {
            this.key = key;
            this.jWTAuthenticationManager = jWTAuthenticationManager;
        }

        public AuthenticationResponse Refresh(RefreshCredentials refreshCred)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            SecurityToken validatedToken;

            var principal = tokenHandler.ValidateToken(refreshCred.JwtToken,
                new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(key),
                    ValidateIssuer = false,
                    ValidateAudience = false,
                    ValidateLifetime = false
                },
                out validatedToken);

            var jwtToken = validatedToken as JwtSecurityToken;

            if (jwtToken == null || !jwtToken.Header.Alg.Equals(SecurityAlgorithms.HmacSha256, StringComparison.InvariantCultureIgnoreCase))
            {
                throw new SecurityTokenException("Invalid token passed!");
            }

            var userName = principal.Identity.Name;

            if (refreshCred.RefreshToken != jWTAuthenticationManager.UsersRefreshTokens[userName])
            {
                throw new SecurityTokenException("Invalid token passed!");
            }

            return jWTAuthenticationManager.Authenticate(userName, principal.Claims.ToArray());
        }
    }
}

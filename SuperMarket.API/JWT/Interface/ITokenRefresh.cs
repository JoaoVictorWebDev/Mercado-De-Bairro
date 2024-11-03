using SuperMarket.API.JWT.Model;

namespace SuperMarket.API.JWT.Interface
{
    public interface ITokenRefresh
    {
        AuthenticationResponse Refresh(RefreshCredentials refreshCred);
    }

}

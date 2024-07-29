using Microsoft.AspNetCore.Components.Authorization;

namespace SomosSolar.WebApp.Security;

public interface ICookieAuthenticationStateProvider
{
    Task<bool> CheckAuthenticateAsync();
    Task<AuthenticationState> GetAuthenticationStateAsync();
    void NotifyAuthenticationStateChanged();
}

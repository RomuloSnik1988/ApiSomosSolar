using SomoSSolar.Core.Requests.Account;
using SomoSSolar.Core.Responses;

namespace SomoSSolar.Core.Handlers;

public interface IAccountHandler
{
    Task<Response<string>> LoginAsync(LoginRequest request);
    Task<Response<string>> RegisterAsync(RegisterRequest request);
    Task LogoutAsync();
}

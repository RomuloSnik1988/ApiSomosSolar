using SomoSSolar.Core.Handlers;
using SomoSSolar.Core.Requests.Account;
using SomoSSolar.Core.Responses;
using System.Net.Http.Json;
using System.Text;

namespace SomosSolar.WebApp.Handlers
{
    public class AccountHandler(IHttpClientFactory httpClientFactory) : IAccountHandler
    {
        private readonly HttpClient _cliente = httpClientFactory.CreateClient(Configuration.HttpClientName);

        public async Task<Response<string>> LoginAsync(LoginRequest request)
        {
            var result = await _cliente.PostAsJsonAsync("v1/identity/login?useCookies=true", request);
            return result.IsSuccessStatusCode
                ? new Response<string>("Login realizado com sucesso", 200, "Login realizado com sucesso")
                : new Response<string>(null, 400, "Falha ao realizar o login");
        }
        public async Task<Response<string>> RegisterAsync(RegisterRequest request)
        {
            var result = await _cliente.PostAsJsonAsync("v1/identity/register", request);
            return result.IsSuccessStatusCode
                ? new Response<string>("Cadastro realizado com sucesso", 201, "Cadastro realizado com sucesso")
                : new Response<string>(null, 400, "Não foi possível realizar seu cadastro");
        }
        public async Task LogoutAsync()
        {
            var emptyContent = new StringContent("{}", Encoding.UTF8, "application/json");
            await _cliente.PostAsJsonAsync("v1/identity/logout", emptyContent);
        }

    }
}

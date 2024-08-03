using SomoSSolar.Core.Models;
using SomoSSolar.Core.Requests.Cliente;
using SomoSSolar.Core.Requests.Clientes;
using SomoSSolar.Core.Responses;

namespace SomoSSolar.Core.Handlers.Clientes;

public interface IClienteHandler
{
    Task<Response<Cliente?>> CreateAsync(CreateClienteRequest request);
    Task<Response<Cliente?>> UpdateAsync(UpdateClienteRequest request);
    Task<Response<Cliente?>> DeleteAsync(DeleteClienteRequest request);
    Task<Response<Cliente?>> GetByIdAsync(GetClienteByIdRequest request);
    Task<PagedResponse<List<Cliente?>>> GetAllAsync(GetAllClientesRequest request);

   
}

using SomoSSolar.Core.Models;
using SomoSSolar.Core.Requests.Vendas;
using SomoSSolar.Core.Responses;

namespace SomoSSolar.Core.Handlers.Vendas;

public interface IVendasHendler
{
    Task<Response<Venda?>> CreateAsync(CreateVendaRequest request);
    Task<Response<Venda?>> UpdateAsync(UpdateVendaRequest request);
    Task<Response<Venda?>> DeleteAsync(DeleteVendaRequest request);
    Task<Response<Venda?>> GetByIdAsync(GetVendaByIdRequest request);
    Task<PagedResponse<List<Venda?>>> GetAllAsync(GetAllVendasRequest request);
}

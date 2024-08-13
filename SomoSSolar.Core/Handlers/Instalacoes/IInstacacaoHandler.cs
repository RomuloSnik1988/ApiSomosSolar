using SomoSSolar.Core.Models;
using SomoSSolar.Core.Requests.Instalacoes;
using SomoSSolar.Core.Requests.Vendas;
using SomoSSolar.Core.Responses;

namespace SomoSSolar.Core.Handlers.Instalacoes;

public interface IInstacacaoHandler
{
    Task<Response<Instalacao?>> CreateAsync(CreateInstalacaoRequest request);
    Task<Response<Instalacao?>> UpdateAsync(UpdateInstalacaoRequest request);
    Task<Response<Instalacao?>> DeleteAsync(DeleteInstalacaoRequest request);
    Task<Response<Instalacao?>> GetByIdAsync(GetInstalacaoByIdRequest request);
    Task<PagedResponse<IEnumerable<Instalacao?>>> GetAllAsync(GetAllInstacoesRequest request);
    Task<Response<List<Instalacao?>>> GetByEnderecoAsync(GetInstacalaoByEnderecoRequest request);
}

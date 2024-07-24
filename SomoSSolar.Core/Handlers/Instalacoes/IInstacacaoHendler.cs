using SomoSSolar.Core.Models;
using SomoSSolar.Core.Requests.Instalacoes;
using SomoSSolar.Core.Responses;

namespace SomoSSolar.Core.Handlers.Instalacoes;

public interface IInstacacaoHendler
{
    Task<Response<Instalacao?>> CreateAsync(CreateInstalacaoRequest request);
    Task<Response<Instalacao?>> UpdateAsync(UpdateInstalacaoRequest request);
    Task<Response<Instalacao?>> DeleteAsync(DeleteInstalacaoRequest request);
    Task<Response<Instalacao?>> GetByAsync(GetInstalacaoByIdRequest request);
    Task<Response<Instalacao?>> GetAllAsync(GetAllInstacoesRequest request);
}

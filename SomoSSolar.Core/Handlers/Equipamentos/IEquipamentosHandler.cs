using SomoSSolar.Core.Models;
using SomoSSolar.Core.Requests.Endereco;
using SomoSSolar.Core.Requests.Equipamentos;
using SomoSSolar.Core.Responses;

namespace SomoSSolar.Core.Handlers.Equipamentos;

public interface IEquipamentosHandler
{
    Task<Response<Equipamento?>> CreateAsync(CreateEnderecoRequest request);
    Task<Response<Equipamento?>> UpdateAsync(UpdateEquipamentoRequest request);
    Task<Response<Equipamento?>> DeleteAsync(DeleteEquipamentoRequest request);
    Task<Response<Equipamento?>> GetByIdAsync(GetEquipamentoByIdRequest request);
    Task<Response<Equipamento?>> GetAllAsync(GetAllEquipamentosRequest request);
}

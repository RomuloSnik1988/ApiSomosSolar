using SomoSSolar.Core.Models;
using SomoSSolar.Core.Requests.Endereco;
using SomoSSolar.Core.Requests.Enderecos;
using SomoSSolar.Core.Responses;

namespace SomoSSolar.Core.Handlers.Enderecos;

public interface IEnderecoHandler
{
    Task<Response<Endereco?>> CreateAsync(CreateEnderecoRequest request);
    Task<Response<Endereco?>> UpdateAsync(UpdateEnderecoRequest request);
    Task<Response<Endereco?>> DeleteAsync(DeleteEnderecoRequest request);
    Task<Response<Endereco?>> GetByIdAsync(GetEnderecoByIdRequest request);
    Task<PagedResponse<List<Endereco?>>> GetAllAsync(GetAllEnderecosRequest request);
    
    Task<Response<List<Endereco?>>> GetEnderecoByClienteIdAsync(GetEnderecoByClienteIdRequest request);
    
    //Task<Response<List<Endereco?>>> GetEnderecoByClienteAsync(GetEnderecosClienteRequest request);



}

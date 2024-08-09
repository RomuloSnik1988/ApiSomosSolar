using Microsoft.EntityFrameworkCore;
using SomoSSolar.API.Data;
using SomoSSolar.Core.Handlers.Enderecos;
using SomoSSolar.Core.Models;
using SomoSSolar.Core.Requests.Endereco;
using SomoSSolar.Core.Requests.Enderecos;
using SomoSSolar.Core.Responses;

namespace SomoSSolar.API.Handlers;

public class EnderecoHandler(AppDbContext context) : IEnderecoHandler
{
    public async Task<Response<Endereco?>> CreateAsync(CreateEnderecoRequest request)
    {
        try
        {
            var endereco = new Endereco
            {
                Logradouro = request.Lagradouro,
                Bairro = request.Bairro,
                Numero = request.Numero,
                Complemento = request.Complemento,
                Estado = request.Estado,
                Cidade = request.Cidade,
                Cep = request.Cep,
                ClienteId = request.ClienteId,
            };

            await context.Enderecos.AddAsync(endereco);
            await context.SaveChangesAsync();

            return new Response<Endereco?>(endereco, 201, "Endereço adicionado com sucesso!");
        }
        catch
        {
            return new Response<Endereco?>(null, 500, "Não foi possivel adicionar o endereço");
        }
    }
    public async Task<Response<Endereco?>> UpdateAsync(UpdateEnderecoRequest request)
    {
        try
        {
            var endereco = await context.Enderecos.FirstOrDefaultAsync(x => x.Id == request.Id);

            if (endereco is null)
                return new Response<Endereco?>(null, 404, "Endereço não encontrado");

            endereco.Logradouro = request.Lagradouro;
            endereco.Bairro = request.Bairro;
            endereco.Numero = request.Numero;
            endereco.Complemento = request.Complemento;
            endereco.Estado = request.Estado;
            endereco.Cidade = request.Cidade;
            endereco.Cep = request.Cep;
            endereco.ClienteId = request.ClienteId;

            context.Enderecos.Update(endereco);
            await context.SaveChangesAsync();

            return new Response<Endereco?>(endereco, message: "Endereço atualizado com sucesso");
        }
        catch
        {
            return new Response<Endereco?>(null, 500, "Não foi possível atualizar o endereço");
        }
    }

    public async Task<Response<Endereco?>> DeleteAsync(DeleteEnderecoRequest request)
    {
        try
        {
            var endereco = await context.Enderecos.FirstOrDefaultAsync(x => x.Id == request.Id);

            if (endereco is null)
                return new Response<Endereco?>(null, 404, "Endereço não encontrado");

            context.Enderecos.Remove(endereco);
            await context.SaveChangesAsync();

            return new Response<Endereco?>(endereco, message: "Endereço exluído com sucesso!");
        }
        catch (Exception)
        {
            return new Response<Endereco?>(null, 500, "Não foi possível excluir o endereço");
        }
    }
    public async Task<Response<Endereco?>> GetByIdAsync(GetEnderecoByIdRequest request)
    {
        try
        {
            var endereco = await context.Enderecos.FirstOrDefaultAsync(x => x.Id == request.Id);

            return endereco is null
                ? new Response<Endereco?>(null, 404, "Endereço nao encontrado")
                : new Response<Endereco?>(endereco);
        }
        catch
        {
            return new Response<Endereco?>(null, 500, "Não foi possível localizar o endereço");
        }
    }

    public async Task<PagedResponse<List<Endereco?>>> GetAllAsync(GetAllEnderecosRequest request)
    {
        try
        {
            var query = context.Enderecos.AsNoTracking().OrderBy(x => x.Id);

            var enderecos = await query
                .Skip((request.PageNumber - 1) * request.PageSize)
                .Take(request.PageSize)
                .ToListAsync();

            var count = await query.CountAsync();

            return new PagedResponse<List<Endereco?>>(enderecos, count, request.PageNumber, request.PageSize);
        }
        catch
        {
            return new PagedResponse<List<Endereco?>>(null, 500, "Não foi possível pesquisar os endereços");
        }
    }

    //public async Task<Response<List<Endereco?>>> GetEnderecoByClienteAsync(GetEnderecosClienteRequest request)
    //{
       

    //    var enderecos = await (from endereco in context.Enderecos
    //                           where endereco.ClienteId == request.Id
    //                           select new Endereco
    //                           {
    //                               Logradouro = endereco.Logradouro,
    //                               Bairro = endereco.Bairro,
    //                               Numero = endereco.Numero,
    //                               Complemento = endereco.Complemento,
    //                               Cep = endereco.Cep

    //                           }).ToListAsync();

    //    return enderecos.Count == 0 
    //        ? new Response<List<Endereco?>>(null, 404, "Não encontrado")
    //        : new Response<List<Endereco?>>(enderecos);
    //}

    public async Task<Response<List<Endereco?>>> GetEnderecoByClienteIdAsync(GetEnderecoByClienteIdRequest request)
    {
        try
        {
            var query = context.Enderecos.AsNoTracking().Where(x=> x.ClienteId == request.Id);

            var enderecos = await query.ToListAsync();

            return new Response<List<Endereco?>>(enderecos);
        }
        catch (Exception)
        {
            return new Response<List<Endereco?>>(null, 500, "Não foi possível pesquisar os endereços");
        }
    }
}


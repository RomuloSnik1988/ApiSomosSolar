using Microsoft.EntityFrameworkCore;
using SomoSSolar.API.Data;
using SomoSSolar.Core.Handlers.Clientes;
using SomoSSolar.Core.Models;
using SomoSSolar.Core.Requests.Cliente;
using SomoSSolar.Core.Requests.Clientes;
using SomoSSolar.Core.Responses;

namespace SomoSSolar.API.Handlers;

public class ClienteHandler(AppDbContext context) : IClienteHandler
{
    public async Task<Response<Cliente?>> CreateAsync(CreateClienteRequest request)
    {
        try
        {
            var cliente = new Cliente
            {
                Name = request.Name,
                Sobrenome = request.Sobrenome,
                Documento = request.Documento,
                Celular = request.Celular,
                Email = request.Email,
                DataCadastro = DateTime.UtcNow
            };
            await context.Clientes.AddAsync(cliente);
            await context.SaveChangesAsync();

            return new Response<Cliente?>(cliente, 201, "Cliente adicionado com sucesso!");
        }
        catch 
        {
            return new Response<Cliente?>(null, 500, "Não foi possível adicionar o cliente");
        }
    }
    public async Task<Response<Cliente?>> UpdateAsync(UpdateClienteRequest request)
    {
        try
        {
            //Recupera o cliente pelo Id
            var cliente = await context.Clientes.FirstOrDefaultAsync(x => x.Id == request.Id);

            //Verifica se cliente é nulo
            if (cliente is null)
                return new Response<Cliente?>(null, 404, "Cliente não encontrado");

            cliente.Name = request.Name;
            cliente.Sobrenome = request.Sobrenome;
            cliente.Documento = request.Documento;
            cliente.Celular = request.Celular;
            cliente.Email = request.Email;
            cliente.DataCadastro = request.DataCadastro;

            context.Clientes.Update(cliente);
            await context.SaveChangesAsync();

            return new Response<Cliente?>(cliente, message: "Dados do cliente alterado com sucesso!");
        }
        catch 
        {
            return new Response<Cliente?>(null, 500, "Não foi possível alterar os dados do cliente");
        }
    }
    public async Task<Response<Cliente?>> DeleteAsync(DeleteClienteRequest request)
    {
        try
        {
            var cliente = await context.Clientes.FirstOrDefaultAsync(x => x.Id == request.Id);

            if (cliente is null)
                return new Response<Cliente?>(null, 404, "Cliente não encontrado");

            context.Clientes.Remove(cliente);
            await context.SaveChangesAsync();

            return new Response<Cliente?>(cliente, message: "Cliente Excluido com sucesso");
        }
        catch 
        {
            return new Response<Cliente?>(null, 500, "Não foi possivel exluir o cadastro do cliente");
        }
    }
    public async Task<Response<Cliente?>> GetByIdAsync(GetClienteByIdRequest request)
    {
        try
        {
            var cliente = await context.Clientes.FirstOrDefaultAsync(x => x.Id == request.Id);

            return cliente is null
                ? new Response<Cliente?>(null, 404, "Cliente não encontrado")
                : new Response<Cliente?>(cliente);
        }
        catch 
        {
            return new Response<Cliente?>(null, 500, "Não foi possível localizar o cliente");
        }
    }
    public async Task<PagedResponse<List<Cliente?>>> GetAllAsync(GetAllClientesRequest request)
    {
        try
        {
            var query = context.Clientes.AsNoTracking().OrderBy(x => x.Name);

            var clientes = await query
                .Skip((request.PageNumber - 1) * request.PageSize)
                .Take(request.PageSize)
                .ToListAsync();

            var count = await query
                .CountAsync();

            return new PagedResponse<List<Cliente?>>(clientes, count, request.PageNumber, request.PageSize);
        }
        catch (Exception)
        {
            return new PagedResponse<List<Cliente?>>(null, 500, "Não foi possivel pesquisar os clientes");
        }
    }
}


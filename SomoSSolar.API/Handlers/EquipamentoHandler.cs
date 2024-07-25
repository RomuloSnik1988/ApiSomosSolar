using Microsoft.EntityFrameworkCore;
using SomoSSolar.API.Data;
using SomoSSolar.Core.Handlers.Equipamentos;
using SomoSSolar.Core.Models;
using SomoSSolar.Core.Requests.Equipamentos;
using SomoSSolar.Core.Responses;

namespace SomoSSolar.API.Handlers;

public class EquipamentoHandler(AppDbContext context) : IEquipamentosHandler
{
    public async Task<Response<Equipamento?>> CreateAsync(CreateEquipamentoRequest request)
    {
        try
        {
            var equipamento = new Equipamento
            {
                Tipo = request.Tipo,
                Fornecedor = request.Fornecedor,
                Marca = request.Marca,
                Modelo = request.Modelo,
                Potencia = request.Potencia,
                PotenciaMaxima = request.PotenciaMaxima,
                Peso = request.Peso,
                Tamanho = request.Tamanho,
                ImagemUrl = request.ImagemUrl,
            };

            await context.Equipamentos.AddAsync(equipamento);
            await context.SaveChangesAsync();

            return new Response<Equipamento?>(equipamento, 201, "Equipamento adicionado com sucesso");
        }
        catch 
        {
            return new Response<Equipamento?>(null, 500, "Não foi possível adicionar o equipamento");
        }
    }
    public async Task<Response<Equipamento?>> UpdateAsync(UpdateEquipamentoRequest request)
    {
        try
        {
            var equipamento = await context.Equipamentos.FirstOrDefaultAsync(x => x.Id == request.Id);

            if (equipamento == null)
                return new Response<Equipamento?>(null, 404, "Equipamento não encontrado");

            equipamento.Tipo = request.Tipo;
            equipamento.Fornecedor = request.Fornecedor;
            equipamento.Marca = request.Marca;
            equipamento.Modelo = request.Modelo;
            equipamento.Potencia = request.Potencia;
            equipamento.PotenciaMaxima = request.PotenciaMaxima;
            equipamento.Peso = request.Peso;
            equipamento.Tamanho = request.Tamanho;
            equipamento.ImagemUrl = request.ImagemUrl;

            context.Equipamentos.Update(equipamento);
            await context.SaveChangesAsync();

            return new Response<Equipamento?>(equipamento, message: "Equipamento alterado com sucesso");
        }
        catch 
        {
            return new Response<Equipamento?>(null, 500, "Não foi possével alterar os dados do equipamento");
        }
    }
    public async Task<Response<Equipamento?>> DeleteAsync(DeleteEquipamentoRequest request)
    {
        try
        {
            var equipamento = await context.Equipamentos.FirstOrDefaultAsync(x => x.Id == request.Id);

            if (equipamento == null)
                return new Response<Equipamento?>(null, 404, "Equipamento não encontrado");

            context.Equipamentos.Remove(equipamento);
            await context.SaveChangesAsync();

            return new Response<Equipamento?>(equipamento, message: "Dados do equipamento excluído com sucesso");
        }
        catch (Exception)
        {
            return new Response<Equipamento?>(null, 500, "Não foi possível excluir o equipamento");
        }
    }
    public async Task<Response<Equipamento?>> GetByIdAsync(GetEquipamentoByIdRequest request)
    {
        try
        {
            var equipamento = await context.Equipamentos.FirstOrDefaultAsync(x => x.Id == request.Id);

            return (equipamento is null)
                ? new Response<Equipamento?>(null, 404, "Equipamento não encontrado")
                : new Response<Equipamento?>(equipamento);
        }
        catch 
        {
            return new Response<Equipamento?>(null, 500, "Não foi possível localizar o equipamento");
        }
    }
    public async Task<PagedResponse<List<Equipamento?>>> GetAllAsync(GetAllEquipamentosRequest request)
    {
        try
        {
            var query = context.Equipamentos.AsNoTracking().OrderBy(x => x.Id);

            var equipamentos = await query
                .Skip((request.PageNumber -1) * request.PageSize)
                .Take(request.PageSize)
                .ToListAsync();

            var count = await query.CountAsync();

            return new PagedResponse<List<Equipamento?>>(equipamentos, count, request.PageNumber, request.PageSize);
        }
        catch 
        {
            return new PagedResponse<List<Equipamento?>>(null, 500, "Não foi possível pesquisar os equipamentos");
        }
    }
    

    
}

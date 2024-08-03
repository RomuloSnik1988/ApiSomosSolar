using Microsoft.EntityFrameworkCore;
using SomoSSolar.API.Data;
using SomoSSolar.Core.Handlers.Vendas;
using SomoSSolar.Core.Models;
using SomoSSolar.Core.Requests.Vendas;
using SomoSSolar.Core.Responses;

namespace SomoSSolar.API.Handlers;

public class VendaHandler(AppDbContext context) : IVendasHandler
{
    public async Task<Response<Venda?>> CreateAsync(CreateVendaRequest request)
    {
        try
        {
            var venda = new Venda
            {
                EquipamentoId = request.EquipamentoId,
                Quantidade = request.Quantidade,
                Datadavenda = request.DatadaVenda,
                InstalacaoId = request.InstalacaoId,
            };

            await context.Vendas.AddAsync(venda);
            await context.SaveChangesAsync();

            return new Response<Venda?>(venda, 201, "Venda adicionada com sucesso");
        }
        catch (Exception)
        {
            return new Response<Venda?>(null, 500, "Não foi possível adicionar a venda");
        }
    }
    public async Task<Response<Venda?>> UpdateAsync(UpdateVendaRequest request)
    {
        try
        {
            var venda = await context.Vendas.FirstOrDefaultAsync(x => x.Id == request.Id);

            if (venda == null)
                return new Response<Venda?>(null, 404, "Venda não encontrada");

            venda.EquipamentoId = request.EquipamentoId;
            venda.Quantidade = request.Quantidade;
            venda.Datadavenda = request.DatadaVenda;
            venda.InstalacaoId = request.InstalacaoId;

            context.Vendas.Update(venda);
            await context.SaveChangesAsync();

            return new Response<Venda?>(venda, message: "Venda alterada com sucesso");
        }
        catch (Exception)
        {
            return new Response<Venda?>(null, 500, "Não foi possível alterar a venda");
        }
    }

    public async Task<Response<Venda?>> DeleteAsync(DeleteVendaRequest request)
    {
        try
        {
            var venda = await context.Vendas.FirstOrDefaultAsync(x => x.Id==request.Id);

            if (venda == null)
                return new Response<Venda?>(null, 404, "Venda não encontrada");

            context.Vendas.Remove(venda);
            await context.SaveChangesAsync();

            return new Response<Venda?>(venda, message: "Venda excluida com sucesso");
        }
        catch (Exception)
        {
            return new Response<Venda?>(null, 500, "Não foi possível excluir a venda");
        }
    }
    public async Task<Response<Venda?>> GetByIdAsync(GetVendaByIdRequest request)
    {
        try
        {
            var venda = await context.Vendas.FirstOrDefaultAsync(x=>x.Id==request.Id);

            return venda is null
                ? new Response<Venda?>(null, 404, "Venda não encontrada")
                : new Response<Venda?>(venda);
        }
        catch (Exception)
        {
            return new Response<Venda?>(null, 500, "Nao foi possível localizar a venda");
        }
    }

    public async Task<PagedResponse<List<Venda?>>> GetAllAsync(GetAllVendasRequest request)
    {
        try
        {
            var query = context.Vendas.AsNoTracking().OrderBy(x => x.Datadavenda);

            var vendas = await query
                .Skip((request.PageNumber - 1) * request.PageSize)
                .Take(request.PageSize)
                .ToListAsync();

            var count = await query .CountAsync();

            return new PagedResponse<List<Venda?>>(vendas, count, request.PageNumber, request.PageSize);
        }
        catch (Exception)
        {
            return new PagedResponse<List<Venda?>>(null, 500, "Não foi possivel pesquisar as vendas");
        }
    }

    

   
}

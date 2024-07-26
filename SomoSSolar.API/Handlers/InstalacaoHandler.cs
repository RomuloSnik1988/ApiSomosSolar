using Microsoft.EntityFrameworkCore;
using SomoSSolar.API.Data;
using SomoSSolar.Core.Handlers.Instalacoes;
using SomoSSolar.Core.Models;
using SomoSSolar.Core.Requests.Instalacoes;
using SomoSSolar.Core.Responses;

namespace SomoSSolar.API.Handlers;

public class InstalacaoHandler(AppDbContext context) : IInstacacaoHandler
{
    public async Task<Response<Instalacao?>> CreateAsync(CreateInstalacaoRequest request)
    {
        try
        {
            var instalacao = new Instalacao
            {
                DataInstalacao = request.DataInstalacao,
                Valor = request.Valor,
                Status = request.Status,
                Despesas = request.Despesas,
                EnderecoId = request.EnderecoId,
            };

            await context.Instalacoes.AddAsync(instalacao);
            await context.SaveChangesAsync();

            return new Response<Instalacao?>(instalacao, 201, "Instalação incluída com sucesso");
        }
        catch 
        {
            return new Response<Instalacao?>(null, 500, "Não foi possível incluir a instalação");
        }
    }
    public async Task<Response<Instalacao?>> UpdateAsync(UpdateInstalacaoRequest request)
    {
        try
        {
            var instalacao = await context.Instalacoes.FirstOrDefaultAsync(x => x.Id == request.Id);

            if (instalacao == null)
                return new Response<Instalacao?>(null, 404, "Instalacao não encontrada");

            instalacao.DataInstalacao = request.DataInstalacao;
            instalacao.Valor = request.Valor;
            instalacao.Status = request.Status;
            instalacao.Despesas = request.Despesas;

            context.Instalacoes.Update(instalacao);
            await context.SaveChangesAsync();

            return new Response<Instalacao?>(instalacao, message: "Instalação alterada com sucesso");
        }
        catch 
        {
            return new Response<Instalacao?>(null, 500, "Não foi possível alterar a instalação");
        }
    }

    public async Task<Response<Instalacao?>> DeleteAsync(DeleteInstalacaoRequest request)
    {
        try
        {
            var instalacao = await context.Instalacoes.FirstOrDefaultAsync(x =>x.Id == request.Id);

            if (instalacao == null)
                return new Response<Instalacao?>(null, 404, "Instalação não encontrada");

            context.Instalacoes.Remove(instalacao);
            await context.SaveChangesAsync();

            return new Response<Instalacao?>(instalacao, message: "Instalação removida com sucesso");
        }
        catch 
        {
            return new Response<Instalacao?>(null, 500, "Não foi possível excluir a instalação");
        }
    }
    public async Task<Response<Instalacao?>> GetByAsync(GetInstalacaoByIdRequest request)
    {
        try
        {
            var instalacao = await context.Instalacoes.FirstOrDefaultAsync(x => x.Id == request.Id);

            return instalacao is null
                ? new Response<Instalacao?>(null, 404, "Instalação não encontrada")
                : new Response<Instalacao?>(instalacao);
        }
        catch 
        {
            return new Response<Instalacao?>(null, 500, "Não foi possível encontrar a instalação");
        }
    }

    public async Task<PagedResponse<List<Instalacao?>>> GetAllAsync(GetAllInstacoesRequest request)
    {
        try
        {
            var query = context.Instalacoes.AsNoTracking().OrderBy(x => x.DataInstalacao);

            var instalacoes = await query
                .Skip((request.PageNumber - 1) * request.PageSize)
                .Take(request.PageSize)
                .ToListAsync();

            var count = await query.CountAsync();

            return new PagedResponse<List<Instalacao?>>(instalacoes, count, request.PageNumber, request.PageSize);
        }
        catch (Exception)
        {
            return new PagedResponse<List<Instalacao?>>(null, 500, "Não foi possível pesquisar as instalações");
        }
    }

   

   
}

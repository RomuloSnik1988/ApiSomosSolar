using Microsoft.EntityFrameworkCore;
using SomoSSolar.API.Data;
using SomoSSolar.Core.Handlers.Reports;
using SomoSSolar.Core.Models.Reports;
using SomoSSolar.Core.Requests.Reports;
using SomoSSolar.Core.Responses;

namespace SomoSSolar.API.Handlers;

public class ReportHandler(AppDbContext context) : IReportHandler
{
    public async Task<Response<TotalClientes>?> GetTotalClientesAsync(GetTotalClientesRequest request)
    {
		try
		{
			var data = await context.TotalDeClientes.AsNoTracking().FirstOrDefaultAsync();

			return new Response<TotalClientes>(data);
		}
		catch 
		{
			return new Response<TotalClientes>(null, 400, "Não foi possível retornar a quantidade de clientes");
		}
    }

    public async Task<Response<TotalInstalacoes>?> GetTotalInstalacaoAsync(GetTotalInstalacoesRequest request)
    {
		try
		{
			var data = await context.TotalDeInstalacoes.AsNoTracking().FirstOrDefaultAsync();
          
            return new Response<TotalInstalacoes>(data);
		}
		catch 
		{
			return new Response<TotalInstalacoes>(null, 400, "Não foi possível retornar a quantidade de instalação");
		}
    }

    public async Task<Response<TotalInvesores>?> GetTotalInversoresAsync(GetTotalInvesoresRequest request)
    {
		try
		{
			var data = await context.TotalDeInvesores.AsNoTracking().FirstOrDefaultAsync();

			return new Response<TotalInvesores>(data);
		}
		catch 
		{
			return new Response<TotalInvesores>(null, 500, "Não foi possível retornar o total de inversores");
		}
    }

    public async Task<Response<TotalPainesVenda>?> GetTotalPaineisVendaAsync(GetTotalPaineisVendasRequest request)
    {
		try
		{
			var data = await context.TotalDePaines.AsNoTracking().FirstOrDefaultAsync();

			return new Response<TotalPainesVenda> (data);
		}
		catch 
		{
			return new Response<TotalPainesVenda> (null, 500,"Não foi possível retornar o total de painéis");
		}
    }

    public async Task<Response<List<TotalVendasMensal>?>> GetTotalVendasMensalAsync(GetTotalVendaMensalRequest request)
    {
		try
		{
			var data = await context.TotalDeVendasMensal.AsNoTracking().OrderByDescending(x => x.Year).ThenBy(x => x.Month).ToListAsync(); 

			return new Response<List<TotalVendasMensal>?>(data);
		}
		catch 
		{
			return new Response<List<TotalVendasMensal>?>(null, 500, "Não foi possível obter total de vendas anual");
		}
    }
}

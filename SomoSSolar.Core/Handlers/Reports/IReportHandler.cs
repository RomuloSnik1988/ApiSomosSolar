using SomoSSolar.Core.Models.Reports;
using SomoSSolar.Core.Requests.Reports;
using SomoSSolar.Core.Responses;

namespace SomoSSolar.Core.Handlers.Reports;

public interface IReportHandler 
{
    Task<Response<TotalPainesVenda>?> GetTotalPaineisVendaAsync(GetTotalPaineisVendasRequest request);
    Task<Response<TotalClientes>?> GetTotalClientesAsync(GetTotalClientesRequest request);
    Task<Response<TotalInvesores>?> GetTotalInversoresAsync(GetTotalInvesoresRequest request);
    Task<Response<TotalInstalacoes>?> GetTotalInstalacaoAsync(GetTotalInstalacoesRequest request);
    Task<Response<List<TotalVendasMensal>?>> GetTotalVendasMensalAsync(GetTotalVendaMensalRequest request);
}

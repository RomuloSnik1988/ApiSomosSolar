using System.ComponentModel.DataAnnotations;

namespace SomoSSolar.Core.Requests.Vendas;

public class UpdateVendaRequest
{
    public int Id { get; set; }

    [Required(ErrorMessage = "Equipamento invalido")]
    public int EquipamentoId { get; set; }
    [Required(ErrorMessage = "Quantidade de equipamento inválido")]
    public int Quantidade { get; set; }
    [Required(ErrorMessage = "Informe a data da venda")]
    public DateTime DatadaVenda { get; set; }
    [Required(ErrorMessage = "Informe a instalação")]
    public int InstalacaoId { get; set; }
}

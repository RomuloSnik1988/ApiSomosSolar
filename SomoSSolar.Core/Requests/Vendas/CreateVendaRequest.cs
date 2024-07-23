using System.ComponentModel.DataAnnotations;

namespace SomoSSolar.Core.Requests.Vendas;

public class CreateVendaRequest
{
    [Required(ErrorMessage = "Equipamento invalido")]
    public int EquipamentoId { get; set; }
    [Required(ErrorMessage = "Quantidade de equipamento inválido")]
    public int Quantidade { get; set; }
}

using SomoSSolar.Core.Enums;
using System.ComponentModel.DataAnnotations;

namespace SomoSSolar.Core.Requests.Instalacoes;

public class CreateInstalacaoRequest
{
    [Required(ErrorMessage = "Data da instalação invalida")]
    public DateTime DataInstalacao { get; set; }
    [Required(ErrorMessage = "Valor inválido")]
    [MaxLength(20, ErrorMessage = "O valor deve ter no máximo 20 caracteres")]
    public decimal Valor { get; set; }
    [Required(ErrorMessage = "Status inválido")]
    public EStatus Status { get; set; } = EStatus.Pedido;
    [MaxLength(20, ErrorMessage = "O valor deve ter no máximo 20 caracteres")]
    public decimal Despesas { get; set; }

}

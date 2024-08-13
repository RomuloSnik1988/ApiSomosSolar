using SomoSSolar.Core.Enums;
using SomoSSolar.Core.Models;
using System.ComponentModel.DataAnnotations;

namespace SomoSSolar.Core.Requests.Instalacoes;

public class UpdateInstalacaoRequest
{
    public int Id { get; set; }
    public DateTime DataInstalacao { get; set; } = DateTime.Now;

    [Required(ErrorMessage = "Tipo Instalação deve ser informado")]
    public ETipoInstalacao TipoInstalacao { get; set; }

    [Required(ErrorMessage = "Valor inválido")]
    public decimal Valor { get; set; }

    [Required(ErrorMessage = "Status inválido")]
    public EStatus Status { get; set; } = EStatus.Pedido;

    public decimal Despesas { get; set; }

    [Required(ErrorMessage = "Informe se a instalação suporta ampliação")]
    public EAmpliacaoInstalacao AmpliacaoInstalacao { get; set; }

    [Required(ErrorMessage = "O Endereço deve ser informado")]
    public int EnderecoId { get; set; }

}

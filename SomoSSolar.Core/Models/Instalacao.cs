using SomoSSolar.Core.Enums;

namespace SomoSSolar.Core.Models;

public class Instalacao
{
    public int Id { get; set; }
    public ETipoInstalacao TipoInstalacao { get; set; } = ETipoInstalacao.Instalacao;
    public DateTime? DataInstalacao { get; set; } = DateTime.Now;
    public decimal Valor { get; set; }
    public EStatus Status { get; set; } = EStatus.Pedido;
    public decimal? Despesas { get; set; }
    public EAmpliacaoInstacacao AmpliacaoInstalacao { get; set; } 

    public int ClienteId { get; set; }
    public Cliente Cliente { get; set; } = null!;
    public ICollection<Venda> Venda { get; set; } = null!;
    public int EnderecoId { get; set; }
}

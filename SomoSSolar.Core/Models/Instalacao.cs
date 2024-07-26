using SomoSSolar.Core.Enums;

namespace SomoSSolar.Core.Models;

public class Instalacao
{
    public int Id { get; set; }
    public DateTime? DataInstalacao { get; set; }
    public decimal Valor { get; set; }
    public EStatus Status { get; set; } = EStatus.Pedido;
    public decimal? Despesas { get; set; }

    public Cliente? Cliente { get; set; }
    public ICollection<Venda> Venda { get; set; } = null!;
    public int EnderecoId { get; set; }
    public Endereco? Endereco { get; set; }
}

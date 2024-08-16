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
    public EAmpliacaoInstalacao AmpliacaoInstalacao { get; set; }
    public int ClienteId { get; set; }
    public virtual Cliente? Cliente { get; set; } 
    public List<Venda> Vendas { get; set; } = new List<Venda>();
    public virtual Endereco? Endereco { get; set; }

    public int EnderecoId { get; set; }
    public string NomeCliente => Cliente?.Nome ?? "Nome não disponível";

   
}

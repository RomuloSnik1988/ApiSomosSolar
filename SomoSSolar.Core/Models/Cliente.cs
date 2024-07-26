namespace SomoSSolar.Core.Models;

public class Cliente
{
    public int Id { get; set; }
    public string Nome { get; set; } = string.Empty;
    public string Sobrenome { get; set; } = string.Empty;
    public string Documento { get; set; } = string.Empty;
    public string Celular { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public DateTime DataCadastro { get; set; } = DateTime.UtcNow;
    public ICollection<Endereco> Enderecos { get; set; } = null!;
    public ICollection<Instalacao> Instalacoes { get; set; } = null!;

}

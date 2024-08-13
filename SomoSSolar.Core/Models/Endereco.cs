namespace SomoSSolar.Core.Models;

public class Endereco
{
    public int Id { get; set; }
    public string Logradouro { get; set; } = string.Empty;
    public string Bairro { get; set; } = string.Empty;
    public string Numero { get; set; } = string.Empty;
    public string Complemento { get; set; } = string.Empty;
    public string Estado { get; set; } = "Tocantins";
    public string Cidade { get; set; } = string.Empty;
    public string Cep { get; set; } = string.Empty;
    
    public int ClienteId { get; set; }
    public List<Instalacao> Instalacoes { get; set; } = new List<Instalacao>();
}

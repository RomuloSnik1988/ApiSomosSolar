namespace SomoSSolar.Core.Models;

public class Endereco
{
    public int Id { get; set; }
    public string Lagradouro { get; set; } = string.Empty;
    public string Bairro { get; set; } = string.Empty;
    public string Numero { get; set; } = string.Empty;
    public string Complemento { get; set; } = string.Empty;
    public string Cep { get; set; } = string.Empty;

}

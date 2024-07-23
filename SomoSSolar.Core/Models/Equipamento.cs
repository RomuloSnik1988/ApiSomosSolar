using SomoSSolar.Core.Enums;

namespace SomoSSolar.Core.Models;

public class Equipamento
{
    public int Id { get; set; }
    public int Tipo { get; set; }
    public string Fornecedor { get; set; } = string.Empty;
    public string Marca { get; set; } = string.Empty;
    public string Modelo { get; set; } = string.Empty;
    public string Potencia { get; set; } = string.Empty;
    public string PotenciaMaxima { get; set; } = string.Empty;
    public string Peso { get; set; } = string.Empty;
    public string Tamanho { get; set; } = string.Empty;
    public string ImagemUrl { get; set; } = string.Empty;
    public EIsAtivo Ativo { get; set; } = EIsAtivo.Ativo;
}

using SomoSSolar.Core.Enums;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace SomoSSolar.Core.Requests.Equipamentos;

public class CreateEquipamentoRequest
{
    [Required(ErrorMessage = "Tipo Inválido")]
    [MaxLength(120, ErrorMessage = "O tipo deve ter no máximo 120 catacteres")]
    public string Tipo { get; set; } = string.Empty;
    [Required(ErrorMessage = "Fornecedor Inválido")]
    [MaxLength(120, ErrorMessage = "O fornecedor deve ter no máximo 120 catacteres")]
    public string Fornecedor { get; set; } = string.Empty;
    [Required(ErrorMessage = "Marca Inválido")]
    [MaxLength(50, ErrorMessage = "O marca deve ter no máximo 50 catacteres")]
    public string Marca { get; set; } = string.Empty;
    [Required(ErrorMessage = "Modelo Inválido")]
    [MaxLength(50, ErrorMessage = "O modelo deve ter no máximo 120 catacteres")]
    public string Modelo { get; set; } = string.Empty;
    [Required(ErrorMessage = "Potencia Inválido")]
    [MaxLength(120, ErrorMessage = "A potência deve ter no máximo 120 catacteres")]
    public string Potencia { get; set; } = string.Empty;
    [MaxLength(20, ErrorMessage = "A potência maxíma deve ter no máximo 20 catacteres")]
    public string PotenciaMaxima { get; set; } = string.Empty;
    [Required(ErrorMessage = "Peso Inválido")]
    [MaxLength(20, ErrorMessage = "O peso deve ter no máximo 20 catacteres")]
    public string Peso { get; set; } = string.Empty;
    [Required(ErrorMessage = "Tamanho Inválido")]
    [MaxLength(20, ErrorMessage = "O tamanho deve ter no máximo 20 catacteres")]
    public string Tamanho { get; set; } = string.Empty;
    [MaxLength(120, ErrorMessage = "A imagem deve ter no máximo 120 catacteres")]
    [DisplayName("Imagem")]
    public string ImagemUrl { get; set; } = string.Empty;
    [Required(ErrorMessage ="Informar se o equipamento esta atívo")]
    public EIsAtivo Ativo { get; set; } = EIsAtivo.Ativo;
}

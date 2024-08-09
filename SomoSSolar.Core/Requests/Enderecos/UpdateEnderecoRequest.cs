using System.ComponentModel.DataAnnotations;

namespace SomoSSolar.Core.Requests.Enderecos;

public class UpdateEnderecoRequest
{
    public int Id { get; set; }

    [Required(ErrorMessage = "Logradouro inválido")]
    [MaxLength(120, ErrorMessage = "O lagradouro deve conter no maxímo 120 caracteres")]
    public string Lagradouro { get; set; } = string.Empty;
    [Required(ErrorMessage = "Bairro inválido")]
    [MaxLength(50, ErrorMessage = "O bairro deve conter no maxímo 50 caracteres")]
    public string Bairro { get; set; } = string.Empty;
    [MaxLength(10, ErrorMessage = "O numero deve conter no maxímo 10 caracteres")]
    public string Numero { get; set; } = string.Empty;
    [MaxLength(50, ErrorMessage = "O complemento deve conter no maxímo 50 caracteres")]
    public string Complemento { get; set; } = string.Empty;
    [Required(ErrorMessage = "Estado inválido")]
    [MaxLength(80, ErrorMessage = "O estado deve conter no máximo 80 caracteres")]
    public string Estado { get; set; } = string.Empty;
    [Required(ErrorMessage = "Cidade inválida")]
    [MaxLength(80, ErrorMessage = "A cidade deve conter no máximo 80 caracteres")]
    public string Cidade { get; set; } = string.Empty;
    [Required(ErrorMessage = "CEP inválido")]
    [MaxLength(10, ErrorMessage = "O Cep deve conter no maxímo 10 caracteres")]
    public string Cep { get; set; } = string.Empty;
    public int ClienteId { get; set; }
}

using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace SomoSSolar.Core.Requests.Cliente;

public class CreateClienteRequest
{
    [Required(ErrorMessage = "Nome inválido")]
    [MaxLength(50, ErrorMessage = "O nome deve conter até 50 caracteres")]
    public string Name { get; set; } = string.Empty;
    [Required(ErrorMessage = "Sobrenome inválido")]
    [MaxLength(80, ErrorMessage = "O sobrenome deve conter até 50 caracteres")]
    public string Sobrenome { get; set; } = string.Empty;
    [Required(ErrorMessage = "CPF ou CNPJ inválido")]
    [DisplayName("CPF ou CNPJ")]
    [MaxLength(14, ErrorMessage = "O CPF ou CNPJ deve conter até 14 caracteres")]
    public int Documento { get; set; }
    [Required(ErrorMessage = "Celular inválido")]
    [MaxLength(12, ErrorMessage = "O celular deve conter até 50 caracteres")]
    public string Celular { get; set; } = string.Empty;
    [Required(ErrorMessage = "Email inválido")]
    [MaxLength(80, ErrorMessage = "O email deve conter até 50 caracteres")]
    [EmailAddress(ErrorMessage = "Infome um e-mail válido")]
    public string Email { get; set; } = string.Empty;
    [Required(ErrorMessage = "Data inválida")]
    public DateTime DataCadastro { get; set; } = DateTime.UtcNow;
}

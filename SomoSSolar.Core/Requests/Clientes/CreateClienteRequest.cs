using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace SomoSSolar.Core.Requests.Cliente;

public class CreateClienteRequest
{
    [Required(ErrorMessage = "Nome inválido")]
    [MaxLength(50, ErrorMessage = "O nome deve conter até 50 caracteres")]
    public string Nome { get; set; } = string.Empty;
    [Required(ErrorMessage = "CPF ou CNPJ inválido")]
    [DisplayName("CPF ou CNPJ")]
    [MaxLength(18, ErrorMessage = "O CPF ou CNPJ deve conter até 18 caracteres")]
    public string Documento { get; set; } = string.Empty;
    [Required(ErrorMessage = "Celular inválido")]
    [MaxLength(14, ErrorMessage = "O celular deve conter até 14 caracteres")]
    public string Celular { get; set; } = string.Empty;
    [Required(ErrorMessage = "Email inválido")]
    [MaxLength(80, ErrorMessage = "O email deve conter até 50 caracteres")]
    [EmailAddress(ErrorMessage = "Infome um e-mail válido")]
    public string Email { get; set; } = string.Empty;
    [Required(ErrorMessage = "Data inválida")]
    public DateTime DataCadastro { get; set; } = DateTime.UtcNow;
}

using System.ComponentModel.DataAnnotations;

namespace SomoSSolar.Core.Requests.Account;

public class RegisterRequest
{
    public string UserId { get; set; } = string.Empty;

    [Required(ErrorMessage = "Email inválido")]
    public string Email { get; set; } = string.Empty;
    [Required(ErrorMessage = "Senha inválida")]
    public string Password { get; set; } = string.Empty;
}

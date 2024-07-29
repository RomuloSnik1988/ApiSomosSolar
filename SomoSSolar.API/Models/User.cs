using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace SomoSSolar.API.Models;

public class User : IdentityUser<long>
{
    [Required]
    public List<IdentityRole<long>>? Roles { get; set; }
}

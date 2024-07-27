using Microsoft.AspNetCore.Identity;

namespace SomoSSolar.API.Models;

public class User : IdentityUser<long>
{
    public List<IdentityRole<long>>? Role { get; set; }
}

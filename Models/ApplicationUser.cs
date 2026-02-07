using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace SecureApiWithJwt.Models;

public class ApplicationUser : IdentityUser
{
    [Required, MaxLength(20)]
    public string FirstName { get; set; } = String.Empty;

    [Required, MaxLength(20)]
    public string LastName { get; set; } = String.Empty;

}

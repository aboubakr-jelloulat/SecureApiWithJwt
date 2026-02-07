using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

using SecureApiWithJwt.Models;

namespace SecureApiWithJwt.Data;

// dotnet add package Microsoft.AspNetCore.Identity.EntityFrameworkCore
public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    {
    }
}

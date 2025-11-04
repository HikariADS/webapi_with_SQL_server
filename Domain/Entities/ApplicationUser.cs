using Microsoft.AspNetCore.Identity;

namespace WebApi_With_SQL_Server.Domain.Entities
{
    public class ApplicationUser : IdentityUser
    {
        public string? FullName { get; set; }
    }
}

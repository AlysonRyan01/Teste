using Microsoft.AspNetCore.Identity;

namespace Test.MinimalApi.Models;

public class ApplicationUser : IdentityUser<long>
{
    public List<IdentityRole<long>>? Roles { get; set; }
}
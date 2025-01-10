using System.Reflection;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Test.Core.Models;
using Test.MinimalApi.Models;

namespace Test.MinimalApi.Data;

public class TestDbContext(DbContextOptions<TestDbContext> options) : IdentityDbContext
<
    ApplicationUser, IdentityRole<long>, long, IdentityUserClaim<long>,
    IdentityUserRole<long>, IdentityUserLogin<long>, IdentityRoleClaim<long>, IdentityUserToken<long>>(options)

{
    public DbSet<Product> Products { get; set; }
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
    }
}
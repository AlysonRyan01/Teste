using System.Reflection;
using Microsoft.EntityFrameworkCore;
using Test.Core.Models;

namespace Test.MinimalApi.Data;

public class TestDbContext : DbContext
{
    public DbSet<Product> Products { get; set; }
    
    public TestDbContext(DbContextOptions<TestDbContext> options) : base(options)
    {
        
    }
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
    }
}
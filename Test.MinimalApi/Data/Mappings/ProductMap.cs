using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Test.Core.Models;

namespace Test.MinimalApi.Data.Mappings;

public class ProductMap : IEntityTypeConfiguration<Product>
{
    public void Configure(EntityTypeBuilder<Product> builder)
    {
        builder.ToTable("Product");
        
        builder.HasKey(x => x.Id);
        
        builder.Property(x => x.Title)
            .IsRequired()
            .HasColumnType("NVARCHAR")
            .HasMaxLength(50);

        builder.Property(x => x.Price)
            .IsRequired()
            .HasColumnType("decimal");
        
        builder.Property(x => x.UserId)
            .IsRequired()
            .HasColumnType("NVARCHAR")
            .HasMaxLength(128);

        builder.Property(x => x.Type)
            .IsRequired();
    }
}
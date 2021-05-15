using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProductService.Infrastructure.Database.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductService.Infrastructure.Database.Config
{
    /// <summary>
    /// Konfiguration-Klasse für ProductEntity
    /// </summary>
    internal sealed class ProductConfiguration : IEntityTypeConfiguration<ProductEntity>
    {
        public void Configure(EntityTypeBuilder<ProductEntity> builder)
        {
            builder.HasKey(e => e.Id);
            builder.Property(e => e.Id).HasColumnName("Id").HasColumnType("int").UseIdentityColumn();
            builder.Property(e => e.Name).HasColumnName("Name").HasColumnType("text").IsRequired(true).IsUnicode();
            builder.Property(e => e.Description).HasColumnName("Description").HasColumnType("text").IsRequired(true).IsUnicode();
            builder.Property(e => e.Price).HasColumnName("Price").HasColumnType("decimal(18,2)").IsRequired(true);
            builder.Property(e => e.CategoryId).HasColumnName("CategoryId").HasColumnType("int").IsRequired(true);
            builder.HasOne(e => e.Category)
                .WithMany()
                .HasForeignKey(f => f.CategoryId);
            builder.ToTable("Products");
        }
    }
}

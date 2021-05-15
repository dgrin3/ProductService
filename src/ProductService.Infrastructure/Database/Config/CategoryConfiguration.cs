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
    /// Konfiguration-Klasse für CategoryEntity
    /// </summary>
    internal sealed class CategoryConfiguration
    {
        public void Configure(EntityTypeBuilder<CategoryEntity> builder)
        {
            builder.HasKey(e => e.Id);
            builder.Property(e => e.Id).HasColumnName("Id").HasColumnType("int").UseIdentityColumn();
            builder.Property(e => e.Name).HasColumnName("Name").HasColumnType("text").IsRequired(true).IsUnicode();
            builder.ToTable("Categories");
        }
    }
}

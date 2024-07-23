using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SomoSSolar.Core.Models;

namespace SomoSSolar.API.Data.Mapping;

public class VendaMapping : IEntityTypeConfiguration<Venda>
{
    public void Configure(EntityTypeBuilder<Venda> builder)
    {
        builder.ToTable("Venda");
        builder.HasKey(x => x.Id);
               
        builder.Property(x => x.Quantidade)
           .IsRequired(true)
           .HasColumnType("VARCHAR")
           .HasMaxLength(20);
    }
}

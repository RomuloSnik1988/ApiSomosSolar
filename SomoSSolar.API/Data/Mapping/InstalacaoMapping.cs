using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SomoSSolar.Core.Models;

namespace SomoSSolar.API.Data.Mapping;

public class InstalacaoMapping : IEntityTypeConfiguration<Instalacao>
{
    public void Configure(EntityTypeBuilder<Instalacao> builder)
    {
        builder.ToTable("Instalacao");
        builder.HasKey(x => x.Id);

        builder.Property(x => x.Valor)
          .IsRequired(true)
          .HasColumnType("MONEY")
          .HasMaxLength(20);

        builder.Property(x => x.Status)
          .IsRequired(true)
          .HasColumnType("VARCHAR")
          .HasMaxLength(10);

        builder.Property(x => x.Despesas)
          .IsRequired(true)
          .HasColumnType("MONEY")
          .HasMaxLength(20);

    }
}

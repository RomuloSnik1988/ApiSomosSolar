using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SomoSSolar.Core.Models;
using System.Reflection.Emit;

namespace SomoSSolar.API.Data.Mapping;

public class InstalacaoMapping : IEntityTypeConfiguration<Instalacao>
{
    public void Configure(EntityTypeBuilder<Instalacao> builder)
    {
        builder.ToTable("Instalacao");
        builder.HasKey(x => x.Id);

        builder.Property(x => x.DataInstalacao)
            .IsRequired(false);

        builder.Property(x => x.TipoInstalacao)
            .HasColumnType("SMALLINT");

        builder.Property(x => x.Valor)
          .IsRequired(true)
          .HasColumnType("MONEY");

        builder.Property(x => x.Status)
          .IsRequired(true)
          .HasColumnType("VARCHAR")
          .HasMaxLength(10);

        builder.Property(x => x.Despesas)
          .HasColumnType("MONEY");

        builder.Property(x => x.AmpliacaoInstalacao)
            .HasColumnType("SMALLINT");

        builder.Property(x => x.EnderecoId)
            .IsRequired(true)
            .HasMaxLength(20);


    }


}

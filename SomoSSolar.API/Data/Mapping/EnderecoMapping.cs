using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SomoSSolar.Core.Models;

namespace SomoSSolar.API.Data.Mapping;

public class EnderecoMapping : IEntityTypeConfiguration<Endereco>
{
    public void Configure(EntityTypeBuilder<Endereco> builder)
    {
        builder.ToTable("Endereco");
        builder.HasKey(x => x.Id);

        builder.Property(x => x.Lagradouro)
           .IsRequired(true)
           .HasColumnType("NVARCHAR")
           .HasMaxLength(120);

        builder.Property(x => x.Bairro)
          .IsRequired(true)
          .HasColumnType("NVARCHAR")
          .HasMaxLength(50);

        builder.Property(x => x.Numero)
          .HasColumnType("NVARCHAR")
          .HasMaxLength(10);

        builder.Property(x => x.Complemento)
        .HasColumnType("NVARCHAR")
        .HasMaxLength(50);

        builder.Property(x => x.Cep)
          .IsRequired(true)
          .HasColumnType("NVARCHAR")
          .HasMaxLength(10);
    }
}

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SomoSSolar.Core.Models;

namespace SomoSSolar.API.Data.Mapping;

public class EquipamentoMapping : IEntityTypeConfiguration<Equipamento>
{
    public void Configure(EntityTypeBuilder<Equipamento> builder)
    {
        builder.ToTable("Equipamento");
        builder.HasKey(x => x.Id);

        builder.Property(x => x.Tipo)
           .IsRequired(true)
           .HasColumnType("NVARCHAR")
           .HasMaxLength(120);

        builder.Property(x => x.Fornecedor)
           .IsRequired(true)
           .HasColumnType("NVARCHAR")
           .HasMaxLength(50);

        builder.Property(x => x.Marca)
           .IsRequired(true)
           .HasColumnType("NVARCHAR")
           .HasMaxLength(50);

        builder.Property(x => x.Modelo)
           .IsRequired(true)
           .HasColumnType("NVARCHAR")
           .HasMaxLength(50);

        builder.Property(x => x.Potencia)
           .IsRequired(true)
           .HasColumnType("VARCHAR")
           .HasMaxLength(20);

        builder.Property(x => x.PotenciaMaxima)
           .IsRequired(false)
           .HasColumnType("VARCHAR")
           .HasMaxLength(20);

        builder.Property(x => x.Peso)
          .IsRequired(false)
          .HasColumnType("VARCHAR")
          .HasMaxLength(20);

        builder.Property(x => x.Tamanho)
          .IsRequired(false)
          .HasColumnType("VARCHAR")
          .HasMaxLength(20);

        builder.Property(x => x.ImagemUrl)
          .IsRequired(false)
          .HasColumnType("NVARCHAR")
          .HasMaxLength(120);

        builder.Property(x => x.Ativo)
          .IsRequired(true)
          .HasColumnType("VARCHAR")
          .HasMaxLength(10);

    }
}

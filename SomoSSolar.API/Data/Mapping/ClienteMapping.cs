﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SomoSSolar.Core.Models;

namespace SomoSSolar.API.Data.Mapping;

public class ClienteMapping : IEntityTypeConfiguration<Cliente>
{
    public void Configure(EntityTypeBuilder<Cliente> builder)
    {
        builder.ToTable("Cliente");
        builder.HasKey(x => x.Id);

        builder.Property(x => x.Name)
            .IsRequired(true)
            .HasColumnType("NVARCHAR")
            .HasMaxLength(50);

        builder.Property(x => x.Sobrenome)
            .IsRequired(true)
            .HasColumnType("NVARCHAR")
            .HasMaxLength(80);

        builder.Property(x => x.Documento)
            .IsRequired(true)
            .HasColumnType("NVARCHAR")
            .HasMaxLength(18);

        builder.Property(x => x.Celular)
             .IsRequired(true)
             .HasColumnType("NVARCHAR")
              .HasMaxLength(12);

        builder.Property(x => x.Email)
            .IsRequired(true)
            .HasColumnType("NVARCHAR")
            .HasMaxLength(50);

        builder.Property(x => x.DataCadastro)
            .IsRequired(true);
           

    }
}

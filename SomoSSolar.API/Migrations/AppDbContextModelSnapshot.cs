﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using SomoSSolar.API.Data;

#nullable disable

namespace SomoSSolar.API.Migrations
{
    [DbContext(typeof(AppDbContext))]
    partial class AppDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.7")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole<long>", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"));

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<long?>("UserId")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.HasIndex("UserId");

                    b.ToTable("IdentityRole", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<long>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("ClaimType")
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<string>("ClaimValue")
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<long>("RoleId")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.ToTable("IdentityRoleClaim", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<long>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("ClaimType")
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<string>("ClaimValue")
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<long>("UserId")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("IdentityClaim", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<long>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("ProviderKey")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("ProviderDisplayName")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<long>("UserId")
                        .HasColumnType("bigint");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("IdentityUserLogin", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<long>", b =>
                {
                    b.Property<long>("UserId")
                        .HasColumnType("bigint");

                    b.Property<long>("RoleId")
                        .HasColumnType("bigint");

                    b.HasKey("UserId", "RoleId");

                    b.ToTable("IdentityUserRole", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<long>", b =>
                {
                    b.Property<long>("UserId")
                        .HasColumnType("bigint");

                    b.Property<string>("LoginProvider")
                        .HasMaxLength(120)
                        .HasColumnType("nvarchar(120)");

                    b.Property<string>("Name")
                        .HasMaxLength(120)
                        .HasColumnType("nvarchar(120)");

                    b.Property<string>("Value")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("IdentityUserToken", (string)null);
                });

            modelBuilder.Entity("SomoSSolar.API.Models.User", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"));

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasMaxLength(180)
                        .HasColumnType("nvarchar(180)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("bit");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("bit");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(180)
                        .HasColumnType("nvarchar(180)");

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(180)
                        .HasColumnType("nvarchar(180)");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("bit");

                    b.Property<string>("UserName")
                        .HasMaxLength(180)
                        .HasColumnType("nvarchar(180)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .IsUnique()
                        .HasFilter("[NormalizedEmail] IS NOT NULL");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("IdentityUser", (string)null);
                });

            modelBuilder.Entity("SomoSSolar.Core.Models.Cliente", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Celular")
                        .IsRequired()
                        .HasMaxLength(14)
                        .HasColumnType("NVARCHAR");

                    b.Property<DateTime>("DataCadastro")
                        .HasColumnType("datetime2");

                    b.Property<string>("Documento")
                        .IsRequired()
                        .HasMaxLength(18)
                        .HasColumnType("NVARCHAR");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("NVARCHAR");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasMaxLength(250)
                        .HasColumnType("NVARCHAR");

                    b.HasKey("Id");

                    b.ToTable("Cliente", (string)null);
                });

            modelBuilder.Entity("SomoSSolar.Core.Models.Endereco", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Bairro")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("NVARCHAR");

                    b.Property<string>("Cep")
                        .IsRequired()
                        .HasMaxLength(10)
                        .HasColumnType("NVARCHAR");

                    b.Property<string>("Cidade")
                        .IsRequired()
                        .HasMaxLength(80)
                        .HasColumnType("NVARCHAR");

                    b.Property<int>("ClienteId")
                        .HasMaxLength(15)
                        .HasColumnType("int");

                    b.Property<string>("Complemento")
                        .HasMaxLength(50)
                        .HasColumnType("NVARCHAR");

                    b.Property<string>("Estado")
                        .IsRequired()
                        .HasMaxLength(80)
                        .HasColumnType("NVARCHAR");

                    b.Property<string>("Logradouro")
                        .IsRequired()
                        .HasMaxLength(120)
                        .HasColumnType("NVARCHAR");

                    b.Property<string>("Numero")
                        .IsRequired()
                        .HasMaxLength(10)
                        .HasColumnType("NVARCHAR");

                    b.HasKey("Id");

                    b.HasIndex("ClienteId");

                    b.ToTable("Endereco", (string)null);
                });

            modelBuilder.Entity("SomoSSolar.Core.Models.Equipamento", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<short>("Ativo")
                        .HasColumnType("SMALLINT");

                    b.Property<string>("Fornecedor")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("NVARCHAR");

                    b.Property<string>("ImagemUrl")
                        .HasMaxLength(120)
                        .HasColumnType("NVARCHAR");

                    b.Property<string>("Marca")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("NVARCHAR");

                    b.Property<string>("Modelo")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("NVARCHAR");

                    b.Property<string>("Peso")
                        .HasMaxLength(20)
                        .HasColumnType("VARCHAR");

                    b.Property<string>("Potencia")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("VARCHAR");

                    b.Property<string>("PotenciaMaxima")
                        .HasMaxLength(20)
                        .HasColumnType("VARCHAR");

                    b.Property<string>("Tamanho")
                        .HasMaxLength(20)
                        .HasColumnType("VARCHAR");

                    b.Property<short>("Tipo")
                        .HasColumnType("SMALLINT");

                    b.HasKey("Id");

                    b.ToTable("Equipamento", (string)null);
                });

            modelBuilder.Entity("SomoSSolar.Core.Models.Instalacao", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<short>("AmpliacaoInstalacao")
                        .HasColumnType("SMALLINT");

                    b.Property<int>("ClienteId")
                        .HasColumnType("int");

                    b.Property<DateTime?>("DataInstalacao")
                        .HasColumnType("datetime2");

                    b.Property<decimal?>("Despesas")
                        .HasColumnType("MONEY");

                    b.Property<int>("EnderecoId")
                        .HasMaxLength(20)
                        .HasColumnType("int");

                    b.Property<string>("Status")
                        .IsRequired()
                        .HasMaxLength(10)
                        .HasColumnType("VARCHAR");

                    b.Property<short>("TipoInstalacao")
                        .HasColumnType("SMALLINT");

                    b.Property<decimal>("Valor")
                        .HasColumnType("MONEY");

                    b.HasKey("Id");

                    b.HasIndex("ClienteId");

                    b.HasIndex("EnderecoId");

                    b.ToTable("Instalacao", (string)null);
                });

            modelBuilder.Entity("SomoSSolar.Core.Models.Reports.TotalClientes", b =>
                {
                    b.Property<int>("TotalDeClientes")
                        .HasColumnType("int");

                    b.ToTable((string)null);

                    b.ToView("VwGetTotalClientes", (string)null);
                });

            modelBuilder.Entity("SomoSSolar.Core.Models.Reports.TotalInstalacoes", b =>
                {
                    b.ToTable((string)null);

                    b.ToView("VwGetTotalInstalacoes", (string)null);
                });

            modelBuilder.Entity("SomoSSolar.Core.Models.Reports.TotalInvesores", b =>
                {
                    b.Property<int>("TotalDeInversores")
                        .HasColumnType("int");

                    b.ToTable((string)null);

                    b.ToView("VwGetTotalInversoresVendas", (string)null);
                });

            modelBuilder.Entity("SomoSSolar.Core.Models.Reports.TotalPainesVenda", b =>
                {
                    b.Property<int>("TotalDePaineis")
                        .HasColumnType("int");

                    b.ToTable((string)null);

                    b.ToView("VwGetTotalPaineisVendas", (string)null);
                });

            modelBuilder.Entity("SomoSSolar.Core.Models.Venda", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("EquipamentoId")
                        .HasColumnType("int");

                    b.Property<int>("InstalacaoId")
                        .HasMaxLength(20)
                        .HasColumnType("int");

                    b.Property<string>("Quantidade")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("VARCHAR");

                    b.HasKey("Id");

                    b.HasIndex("EquipamentoId");

                    b.HasIndex("InstalacaoId");

                    b.ToTable("Venda", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole<long>", b =>
                {
                    b.HasOne("SomoSSolar.API.Models.User", null)
                        .WithMany("Roles")
                        .HasForeignKey("UserId");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<long>", b =>
                {
                    b.HasOne("SomoSSolar.API.Models.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<long>", b =>
                {
                    b.HasOne("SomoSSolar.API.Models.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<long>", b =>
                {
                    b.HasOne("SomoSSolar.API.Models.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<long>", b =>
                {
                    b.HasOne("SomoSSolar.API.Models.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("SomoSSolar.Core.Models.Endereco", b =>
                {
                    b.HasOne("SomoSSolar.Core.Models.Cliente", "Cliente")
                        .WithMany("Enderecos")
                        .HasForeignKey("ClienteId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Cliente");
                });

            modelBuilder.Entity("SomoSSolar.Core.Models.Instalacao", b =>
                {
                    b.HasOne("SomoSSolar.Core.Models.Cliente", "Cliente")
                        .WithMany("Instalacoes")
                        .HasForeignKey("ClienteId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("SomoSSolar.Core.Models.Endereco", "Endereco")
                        .WithMany("Instalacoes")
                        .HasForeignKey("EnderecoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Cliente");

                    b.Navigation("Endereco");
                });

            modelBuilder.Entity("SomoSSolar.Core.Models.Venda", b =>
                {
                    b.HasOne("SomoSSolar.Core.Models.Equipamento", "Equipamento")
                        .WithMany()
                        .HasForeignKey("EquipamentoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("SomoSSolar.Core.Models.Instalacao", "Instalacao")
                        .WithMany("Vendas")
                        .HasForeignKey("InstalacaoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Equipamento");

                    b.Navigation("Instalacao");
                });

            modelBuilder.Entity("SomoSSolar.API.Models.User", b =>
                {
                    b.Navigation("Roles");
                });

            modelBuilder.Entity("SomoSSolar.Core.Models.Cliente", b =>
                {
                    b.Navigation("Enderecos");

                    b.Navigation("Instalacoes");
                });

            modelBuilder.Entity("SomoSSolar.Core.Models.Endereco", b =>
                {
                    b.Navigation("Instalacoes");
                });

            modelBuilder.Entity("SomoSSolar.Core.Models.Instalacao", b =>
                {
                    b.Navigation("Vendas");
                });
#pragma warning restore 612, 618
        }
    }
}

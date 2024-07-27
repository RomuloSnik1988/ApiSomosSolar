﻿using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using SomoSSolar.API.Models;
using SomoSSolar.Core.Models;
using System.Reflection;

namespace SomoSSolar.API.Data;

public class AppDbContext(DbContextOptions<AppDbContext> options) 
    : IdentityDbContext
    <User,IdentityRole<long>,long,IdentityUserClaim<long>,IdentityUserRole<long>,
    IdentityUserLogin<long>,IdentityRoleClaim<long>,IdentityUserToken<long>> (options)
{
    public DbSet<Cliente> Clientes { get; set; } = null!;
    public DbSet<Endereco> Enderecos { get; set; } = null!;
    public DbSet<Equipamento> Equipamentos { get; set; } = null!;
    public DbSet<Instalacao> Instalacoes { get; set; } = null!;
    public DbSet<Venda> Vendas { get; set; } = null!;

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

    }
}

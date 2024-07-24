using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SomoSSolar.API.Migrations
{
    /// <inheritdoc />
    public partial class Initialv1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Cliente",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "NVARCHAR(50)", maxLength: 50, nullable: false),
                    Sobrenome = table.Column<string>(type: "NVARCHAR(80)", maxLength: 80, nullable: false),
                    Documento = table.Column<string>(type: "NVARCHAR(14)", maxLength: 14, nullable: false),
                    Celular = table.Column<string>(type: "NVARCHAR(12)", maxLength: 12, nullable: false),
                    Email = table.Column<string>(type: "NVARCHAR(50)", maxLength: 50, nullable: false),
                    DataCadastro = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cliente", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Equipamento",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Tipo = table.Column<string>(type: "NVARCHAR(120)", maxLength: 120, nullable: false),
                    Fornecedor = table.Column<string>(type: "NVARCHAR(50)", maxLength: 50, nullable: false),
                    Marca = table.Column<string>(type: "NVARCHAR(50)", maxLength: 50, nullable: false),
                    Modelo = table.Column<string>(type: "NVARCHAR(50)", maxLength: 50, nullable: false),
                    Potencia = table.Column<string>(type: "VARCHAR(20)", maxLength: 20, nullable: false),
                    PotenciaMaxima = table.Column<string>(type: "VARCHAR(20)", maxLength: 20, nullable: true),
                    Peso = table.Column<string>(type: "VARCHAR(20)", maxLength: 20, nullable: true),
                    Tamanho = table.Column<string>(type: "VARCHAR(20)", maxLength: 20, nullable: true),
                    ImagemUrl = table.Column<string>(type: "NVARCHAR(120)", maxLength: 120, nullable: true),
                    Ativo = table.Column<string>(type: "VARCHAR(10)", maxLength: 10, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Equipamento", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Endereco",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Lagradouro = table.Column<string>(type: "NVARCHAR(120)", maxLength: 120, nullable: false),
                    Bairro = table.Column<string>(type: "NVARCHAR(50)", maxLength: 50, nullable: false),
                    Numero = table.Column<string>(type: "NVARCHAR(10)", maxLength: 10, nullable: false),
                    Complemento = table.Column<string>(type: "NVARCHAR(50)", maxLength: 50, nullable: false),
                    Cep = table.Column<string>(type: "NVARCHAR(10)", maxLength: 10, nullable: false),
                    ClienteId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Endereco", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Endereco_Cliente_ClienteId",
                        column: x => x.ClienteId,
                        principalTable: "Cliente",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Instalacao",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DataInstalacao = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Valor = table.Column<decimal>(type: "MONEY", maxLength: 20, nullable: false),
                    Status = table.Column<string>(type: "VARCHAR(10)", maxLength: 10, nullable: false),
                    Despesas = table.Column<decimal>(type: "MONEY", maxLength: 20, nullable: false),
                    ClienteId = table.Column<int>(type: "int", nullable: false),
                    EnderecoId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Instalacao", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Instalacao_Cliente_ClienteId",
                        column: x => x.ClienteId,
                        principalTable: "Cliente",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Instalacao_Endereco_EnderecoId",
                        column: x => x.EnderecoId,
                        principalTable: "Endereco",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Venda",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EquipamentoId = table.Column<int>(type: "int", nullable: false),
                    Quantidade = table.Column<string>(type: "VARCHAR(20)", maxLength: 20, nullable: false),
                    InstalacaoId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Venda", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Venda_Equipamento_EquipamentoId",
                        column: x => x.EquipamentoId,
                        principalTable: "Equipamento",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Venda_Instalacao_InstalacaoId",
                        column: x => x.InstalacaoId,
                        principalTable: "Instalacao",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Endereco_ClienteId",
                table: "Endereco",
                column: "ClienteId");

            migrationBuilder.CreateIndex(
                name: "IX_Instalacao_ClienteId",
                table: "Instalacao",
                column: "ClienteId");

            migrationBuilder.CreateIndex(
                name: "IX_Instalacao_EnderecoId",
                table: "Instalacao",
                column: "EnderecoId");

            migrationBuilder.CreateIndex(
                name: "IX_Venda_EquipamentoId",
                table: "Venda",
                column: "EquipamentoId");

            migrationBuilder.CreateIndex(
                name: "IX_Venda_InstalacaoId",
                table: "Venda",
                column: "InstalacaoId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Venda");

            migrationBuilder.DropTable(
                name: "Equipamento");

            migrationBuilder.DropTable(
                name: "Instalacao");

            migrationBuilder.DropTable(
                name: "Endereco");

            migrationBuilder.DropTable(
                name: "Cliente");
        }
    }
}

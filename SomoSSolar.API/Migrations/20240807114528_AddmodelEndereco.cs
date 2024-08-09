using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SomoSSolar.API.Migrations
{
    /// <inheritdoc />
    public partial class AddmodelEndereco : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Cidade",
                table: "Endereco",
                type: "NVARCHAR(80)",
                maxLength: 80,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Estado",
                table: "Endereco",
                type: "NVARCHAR(80)",
                maxLength: 80,
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Cidade",
                table: "Endereco");

            migrationBuilder.DropColumn(
                name: "Estado",
                table: "Endereco");
        }
    }
}

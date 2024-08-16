using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SomoSSolar.API.Migrations
{
    /// <inheritdoc />
    public partial class AddAlteracaoModelInstalacao : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Instalacao_Cliente_ClienteId",
                table: "Instalacao");

            migrationBuilder.AlterColumn<int>(
                name: "ClienteId",
                table: "Instalacao",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Instalacao_Cliente_ClienteId",
                table: "Instalacao",
                column: "ClienteId",
                principalTable: "Cliente",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Instalacao_Cliente_ClienteId",
                table: "Instalacao");

            migrationBuilder.AlterColumn<int>(
                name: "ClienteId",
                table: "Instalacao",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Instalacao_Cliente_ClienteId",
                table: "Instalacao",
                column: "ClienteId",
                principalTable: "Cliente",
                principalColumn: "Id");
        }
    }
}

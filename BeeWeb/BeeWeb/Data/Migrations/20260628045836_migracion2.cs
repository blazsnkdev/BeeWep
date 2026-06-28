using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BeeWeb.Data.Migrations
{
    /// <inheritdoc />
    public partial class migracion2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cliente_TblUsuario_UsuarioId",
                table: "Cliente");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Cliente",
                table: "Cliente");

            migrationBuilder.DropColumn(
                name: "UsuarioRolId",
                table: "TblUsuario");

            migrationBuilder.RenameTable(
                name: "Cliente",
                newName: "TblCliente");

            migrationBuilder.RenameIndex(
                name: "IX_Cliente_UsuarioId",
                table: "TblCliente",
                newName: "IX_TblCliente_UsuarioId");

            migrationBuilder.AddColumn<string>(
                name: "Codigo",
                table: "TblUsuario",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TblCliente",
                table: "TblCliente",
                column: "ClienteId");

            migrationBuilder.CreateTable(
                name: "TblNegocio",
                columns: table => new
                {
                    NegocioId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Direccion = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Rubro = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Descripcion = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TipoMoneda = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UsuarioId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TblNegocio", x => x.NegocioId);
                    table.ForeignKey(
                        name: "FK_TblNegocio_TblUsuario_UsuarioId",
                        column: x => x.UsuarioId,
                        principalTable: "TblUsuario",
                        principalColumn: "UsurioId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TblNegocio_UsuarioId",
                table: "TblNegocio",
                column: "UsuarioId");

            migrationBuilder.AddForeignKey(
                name: "FK_TblCliente_TblUsuario_UsuarioId",
                table: "TblCliente",
                column: "UsuarioId",
                principalTable: "TblUsuario",
                principalColumn: "UsurioId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TblCliente_TblUsuario_UsuarioId",
                table: "TblCliente");

            migrationBuilder.DropTable(
                name: "TblNegocio");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TblCliente",
                table: "TblCliente");

            migrationBuilder.DropColumn(
                name: "Codigo",
                table: "TblUsuario");

            migrationBuilder.RenameTable(
                name: "TblCliente",
                newName: "Cliente");

            migrationBuilder.RenameIndex(
                name: "IX_TblCliente_UsuarioId",
                table: "Cliente",
                newName: "IX_Cliente_UsuarioId");

            migrationBuilder.AddColumn<Guid>(
                name: "UsuarioRolId",
                table: "TblUsuario",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddPrimaryKey(
                name: "PK_Cliente",
                table: "Cliente",
                column: "ClienteId");

            migrationBuilder.AddForeignKey(
                name: "FK_Cliente_TblUsuario_UsuarioId",
                table: "Cliente",
                column: "UsuarioId",
                principalTable: "TblUsuario",
                principalColumn: "UsurioId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}

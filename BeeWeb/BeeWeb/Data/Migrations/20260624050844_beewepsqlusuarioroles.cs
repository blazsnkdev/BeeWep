using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BeeWeb.Data.Migrations
{
    /// <inheritdoc />
    public partial class beewepsqlusuarioroles : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TblRol",
                columns: table => new
                {
                    RolId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Descripcion = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TblRol", x => x.RolId);
                });

            migrationBuilder.CreateTable(
                name: "TblUsuario",
                columns: table => new
                {
                    UsurioId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PasswordHashed = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UsuarioRolId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TblUsuario", x => x.UsurioId);
                });

            migrationBuilder.CreateTable(
                name: "Cliente",
                columns: table => new
                {
                    ClienteId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Apellido = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Telefono = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Direccion = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TipoDocumento = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NumeroDocumento = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UsuarioId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cliente", x => x.ClienteId);
                    table.ForeignKey(
                        name: "FK_Cliente_TblUsuario_UsuarioId",
                        column: x => x.UsuarioId,
                        principalTable: "TblUsuario",
                        principalColumn: "UsurioId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "RolUsuario",
                columns: table => new
                {
                    RolesRolId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UsuariosUsurioId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RolUsuario", x => new { x.RolesRolId, x.UsuariosUsurioId });
                    table.ForeignKey(
                        name: "FK_RolUsuario_TblRol_RolesRolId",
                        column: x => x.RolesRolId,
                        principalTable: "TblRol",
                        principalColumn: "RolId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RolUsuario_TblUsuario_UsuariosUsurioId",
                        column: x => x.UsuariosUsurioId,
                        principalTable: "TblUsuario",
                        principalColumn: "UsurioId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Cliente_UsuarioId",
                table: "Cliente",
                column: "UsuarioId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_RolUsuario_UsuariosUsurioId",
                table: "RolUsuario",
                column: "UsuariosUsurioId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Cliente");

            migrationBuilder.DropTable(
                name: "RolUsuario");

            migrationBuilder.DropTable(
                name: "TblRol");

            migrationBuilder.DropTable(
                name: "TblUsuario");
        }
    }
}

using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BeeWeb.Data.Migrations
{
    /// <inheritdoc />
    public partial class addtablesnewcategoriandmarcas : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TblCategoria",
                columns: table => new
                {
                    CategoriaId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Descripcion = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TblCategoria", x => x.CategoriaId);
                });

            migrationBuilder.CreateTable(
                name: "TblMarca",
                columns: table => new
                {
                    MarcaId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Descripcion = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TblMarca", x => x.MarcaId);
                });

            migrationBuilder.CreateTable(
                name: "TblArticulo",
                columns: table => new
                {
                    ArticuloId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    NumeroParte = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Descripcion = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CategoriaId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    MarcaId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PermiteSeries = table.Column<bool>(type: "bit", nullable: false),
                    UnidadMedida = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TblArticulo", x => x.ArticuloId);
                    table.ForeignKey(
                        name: "FK_TblArticulo_TblCategoria_ArticuloId",
                        column: x => x.ArticuloId,
                        principalTable: "TblCategoria",
                        principalColumn: "CategoriaId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TblArticulo_TblMarca_MarcaId",
                        column: x => x.MarcaId,
                        principalTable: "TblMarca",
                        principalColumn: "MarcaId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TblArticulo_MarcaId",
                table: "TblArticulo",
                column: "MarcaId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TblArticulo");

            migrationBuilder.DropTable(
                name: "TblCategoria");

            migrationBuilder.DropTable(
                name: "TblMarca");
        }
    }
}

using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MiCanasta.Migrations
{
    public partial class PruebaUsuario3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UsuarioTiendas_RolPerfil_RolPerfilId",
                table: "UsuarioTiendas");

            migrationBuilder.DropForeignKey(
                name: "FK_UsuarioTiendas_Tienda_TiendaId",
                table: "UsuarioTiendas");

            migrationBuilder.DropTable(
                name: "Tienda");

            migrationBuilder.DropIndex(
                name: "IX_UsuarioTiendas_RolPerfilId",
                table: "UsuarioTiendas");

            migrationBuilder.DropIndex(
                name: "IX_UsuarioTiendas_TiendaId",
                table: "UsuarioTiendas");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Tienda",
                columns: table => new
                {
                    TiendaId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Descripcion = table.Column<string>(type: "longtext CHARACTER SET utf8mb4", nullable: true),
                    Direccion = table.Column<string>(type: "longtext CHARACTER SET utf8mb4", nullable: true),
                    HoraApertura = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    HoraCierre = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    Latitud = table.Column<string>(type: "longtext CHARACTER SET utf8mb4", nullable: true),
                    Longitud = table.Column<string>(type: "longtext CHARACTER SET utf8mb4", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tienda", x => x.TiendaId);
                });

            migrationBuilder.CreateIndex(
                name: "IX_UsuarioTiendas_RolPerfilId",
                table: "UsuarioTiendas",
                column: "RolPerfilId");

            migrationBuilder.CreateIndex(
                name: "IX_UsuarioTiendas_TiendaId",
                table: "UsuarioTiendas",
                column: "TiendaId");

            migrationBuilder.AddForeignKey(
                name: "FK_UsuarioTiendas_RolPerfil_RolPerfilId",
                table: "UsuarioTiendas",
                column: "RolPerfilId",
                principalTable: "RolPerfil",
                principalColumn: "RolPerfilId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UsuarioTiendas_Tienda_TiendaId",
                table: "UsuarioTiendas",
                column: "TiendaId",
                principalTable: "Tienda",
                principalColumn: "TiendaId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}

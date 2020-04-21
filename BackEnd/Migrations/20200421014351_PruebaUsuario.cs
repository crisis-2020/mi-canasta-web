using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MiCanasta.Migrations
{
    public partial class PruebaUsuario : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Familia",
                columns: table => new
                {
                    FamiliaId = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Nombre = table.Column<string>(nullable: true),
                    AceptaSolicitudes = table.Column<bool>(nullable: false),
                    Cantidad = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Familia", x => x.FamiliaId);
                });

            migrationBuilder.CreateTable(
                name: "Perfil",
                columns: table => new
                {
                    PerfilId = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Descripcion = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Perfil", x => x.PerfilId);
                });

            migrationBuilder.CreateTable(
                name: "Tienda",
                columns: table => new
                {
                    TiendaId = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Descripcion = table.Column<string>(nullable: true),
                    Direccion = table.Column<string>(nullable: true),
                    Latitud = table.Column<string>(nullable: true),
                    Longitud = table.Column<string>(nullable: true),
                    HoraApertura = table.Column<DateTime>(nullable: false),
                    HoraCierre = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tienda", x => x.TiendaId);
                });

            migrationBuilder.CreateTable(
                name: "Usuarios",
                columns: table => new
                {
                    Dni = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Nombre = table.Column<string>(nullable: false),
                    ApellidoPaterno = table.Column<string>(nullable: false),
                    ApellidoMaterno = table.Column<string>(nullable: false),
                    Contrasena = table.Column<string>(nullable: false),
                    Correo = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuarios", x => x.Dni);
                });

            migrationBuilder.CreateTable(
                name: "RolPerfil",
                columns: table => new
                {
                    RolPerfilId = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Descripcion = table.Column<string>(nullable: true),
                    PerfilId1 = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RolPerfil", x => x.RolPerfilId);
                    table.ForeignKey(
                        name: "FK_RolPerfil_Perfil_PerfilId1",
                        column: x => x.PerfilId1,
                        principalTable: "Perfil",
                        principalColumn: "PerfilId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "UsuariosFamilias",
                columns: table => new
                {
                    UsuarioFamiliaId = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Dni = table.Column<int>(nullable: false),
                    UsuarioDni = table.Column<int>(nullable: true),
                    RolPerfilId = table.Column<int>(nullable: false),
                    FamiliaId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UsuariosFamilias", x => x.UsuarioFamiliaId);
                    table.ForeignKey(
                        name: "FK_UsuariosFamilias_Familia_FamiliaId",
                        column: x => x.FamiliaId,
                        principalTable: "Familia",
                        principalColumn: "FamiliaId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UsuariosFamilias_RolPerfil_RolPerfilId",
                        column: x => x.RolPerfilId,
                        principalTable: "RolPerfil",
                        principalColumn: "RolPerfilId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UsuariosFamilias_Usuarios_UsuarioDni",
                        column: x => x.UsuarioDni,
                        principalTable: "Usuarios",
                        principalColumn: "Dni",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "UsuarioTiendas",
                columns: table => new
                {
                    UsuarioTiendaId = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Dni = table.Column<int>(nullable: false),
                    UsuarioDni = table.Column<int>(nullable: true),
                    RolPerfilId = table.Column<int>(nullable: false),
                    TiendaId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UsuarioTiendas", x => x.UsuarioTiendaId);
                    table.ForeignKey(
                        name: "FK_UsuarioTiendas_RolPerfil_RolPerfilId",
                        column: x => x.RolPerfilId,
                        principalTable: "RolPerfil",
                        principalColumn: "RolPerfilId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UsuarioTiendas_Tienda_TiendaId",
                        column: x => x.TiendaId,
                        principalTable: "Tienda",
                        principalColumn: "TiendaId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UsuarioTiendas_Usuarios_UsuarioDni",
                        column: x => x.UsuarioDni,
                        principalTable: "Usuarios",
                        principalColumn: "Dni",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_RolPerfil_PerfilId1",
                table: "RolPerfil",
                column: "PerfilId1");

            migrationBuilder.CreateIndex(
                name: "IX_UsuariosFamilias_FamiliaId",
                table: "UsuariosFamilias",
                column: "FamiliaId");

            migrationBuilder.CreateIndex(
                name: "IX_UsuariosFamilias_RolPerfilId",
                table: "UsuariosFamilias",
                column: "RolPerfilId");

            migrationBuilder.CreateIndex(
                name: "IX_UsuariosFamilias_UsuarioDni",
                table: "UsuariosFamilias",
                column: "UsuarioDni");

            migrationBuilder.CreateIndex(
                name: "IX_UsuarioTiendas_RolPerfilId",
                table: "UsuarioTiendas",
                column: "RolPerfilId");

            migrationBuilder.CreateIndex(
                name: "IX_UsuarioTiendas_TiendaId",
                table: "UsuarioTiendas",
                column: "TiendaId");

            migrationBuilder.CreateIndex(
                name: "IX_UsuarioTiendas_UsuarioDni",
                table: "UsuarioTiendas",
                column: "UsuarioDni");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "UsuariosFamilias");

            migrationBuilder.DropTable(
                name: "UsuarioTiendas");

            migrationBuilder.DropTable(
                name: "Familia");

            migrationBuilder.DropTable(
                name: "RolPerfil");

            migrationBuilder.DropTable(
                name: "Tienda");

            migrationBuilder.DropTable(
                name: "Usuarios");

            migrationBuilder.DropTable(
                name: "Perfil");
        }
    }
}

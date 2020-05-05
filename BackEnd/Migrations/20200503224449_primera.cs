using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MiCanasta.Migrations
{
    public partial class primera : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Categorias",
                columns: table => new
                {
                    CategoriaId = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Descripcion = table.Column<string>(nullable: true),
                    TipoUnidad = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categorias", x => x.CategoriaId);
                });

            migrationBuilder.CreateTable(
                name: "Familias",
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
                    table.PrimaryKey("PK_Familias", x => x.FamiliaId);
                });

            migrationBuilder.CreateTable(
                name: "Perfiles",
                columns: table => new
                {
                    PerfilId = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Descripcion = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Perfiles", x => x.PerfilId);
                });

            migrationBuilder.CreateTable(
                name: "Tiendas",
                columns: table => new
                {
                    TiendaId = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Descripcion = table.Column<string>(nullable: true),
                    Direccion = table.Column<string>(nullable: true),
                    Latitud = table.Column<string>(nullable: true),
                    Longitud = table.Column<string>(nullable: true),
                    Horario = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tiendas", x => x.TiendaId);
                });

            migrationBuilder.CreateTable(
                name: "Usuarios",
                columns: table => new
                {
                    Dni = table.Column<string>(nullable: false),
                    Nombre = table.Column<string>(nullable: true),
                    ApellidoPaterno = table.Column<string>(nullable: true),
                    ApellidoMaterno = table.Column<string>(nullable: true),
                    Contrasena = table.Column<string>(nullable: true),
                    Correo = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuarios", x => x.Dni);
                });

            migrationBuilder.CreateTable(
                name: "Limites",
                columns: table => new
                {
                    LimiteId = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    CantidadPersona = table.Column<int>(nullable: false),
                    CategoriaId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Limites", x => x.LimiteId);
                    table.ForeignKey(
                        name: "FK_Limites_Categorias_CategoriaId",
                        column: x => x.CategoriaId,
                        principalTable: "Categorias",
                        principalColumn: "CategoriaId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Productos",
                columns: table => new
                {
                    ProductoId = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    CategoriaId = table.Column<int>(nullable: false),
                    Descripcion = table.Column<string>(nullable: true),
                    CantidadUnit = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Productos", x => x.ProductoId);
                    table.ForeignKey(
                        name: "FK_Productos_Categorias_CategoriaId",
                        column: x => x.CategoriaId,
                        principalTable: "Categorias",
                        principalColumn: "CategoriaId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "RolPerfiles",
                columns: table => new
                {
                    RolPerfilId = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Descripcion = table.Column<string>(nullable: true),
                    PerfilId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RolPerfiles", x => x.RolPerfilId);
                    table.ForeignKey(
                        name: "FK_RolPerfiles_Perfiles_PerfilId",
                        column: x => x.PerfilId,
                        principalTable: "Perfiles",
                        principalColumn: "PerfilId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Solicitudes",
                columns: table => new
                {
                    FamiliaId = table.Column<int>(nullable: false),
                    Dni = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Solicitudes", x => new { x.Dni, x.FamiliaId });
                    table.ForeignKey(
                        name: "FK_Solicitudes_Usuarios_Dni",
                        column: x => x.Dni,
                        principalTable: "Usuarios",
                        principalColumn: "Dni",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Solicitudes_Familias_FamiliaId",
                        column: x => x.FamiliaId,
                        principalTable: "Familias",
                        principalColumn: "FamiliaId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UsuarioFamilias",
                columns: table => new
                {
                    Dni = table.Column<string>(nullable: false),
                    FamiliaId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UsuarioFamilias", x => new { x.Dni, x.FamiliaId });
                    table.ForeignKey(
                        name: "FK_UsuarioFamilias_Usuarios_Dni",
                        column: x => x.Dni,
                        principalTable: "Usuarios",
                        principalColumn: "Dni",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UsuarioFamilias_Familias_FamiliaId",
                        column: x => x.FamiliaId,
                        principalTable: "Familias",
                        principalColumn: "FamiliaId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UsuarioTiendas",
                columns: table => new
                {
                    Dni = table.Column<string>(nullable: false),
                    TiendaId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UsuarioTiendas", x => new { x.Dni, x.TiendaId });
                    table.ForeignKey(
                        name: "FK_UsuarioTiendas_Usuarios_Dni",
                        column: x => x.Dni,
                        principalTable: "Usuarios",
                        principalColumn: "Dni",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UsuarioTiendas_Tiendas_TiendaId",
                        column: x => x.TiendaId,
                        principalTable: "Tiendas",
                        principalColumn: "TiendaId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Historiales",
                columns: table => new
                {
                    FamiliaId = table.Column<int>(nullable: false),
                    TiendaId = table.Column<int>(nullable: false),
                    ProductoId = table.Column<int>(nullable: false),
                    Cantidad = table.Column<int>(nullable: false),
                    FechaCompra = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Historiales", x => new { x.FamiliaId, x.TiendaId, x.ProductoId });
                    table.ForeignKey(
                        name: "FK_Historiales_Familias_FamiliaId",
                        column: x => x.FamiliaId,
                        principalTable: "Familias",
                        principalColumn: "FamiliaId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Historiales_Productos_ProductoId",
                        column: x => x.ProductoId,
                        principalTable: "Productos",
                        principalColumn: "ProductoId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Historiales_Tiendas_TiendaId",
                        column: x => x.TiendaId,
                        principalTable: "Tiendas",
                        principalColumn: "TiendaId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Stocks",
                columns: table => new
                {
                    ProductoId = table.Column<int>(nullable: false),
                    TiendaId = table.Column<int>(nullable: false),
                    Cantidad = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Stocks", x => new { x.ProductoId, x.TiendaId });
                    table.ForeignKey(
                        name: "FK_Stocks_Productos_ProductoId",
                        column: x => x.ProductoId,
                        principalTable: "Productos",
                        principalColumn: "ProductoId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Stocks_Tiendas_TiendaId",
                        column: x => x.TiendaId,
                        principalTable: "Tiendas",
                        principalColumn: "TiendaId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "RolUsuarios",
                columns: table => new
                {
                    Dni = table.Column<string>(nullable: false),
                    RolPerfilId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RolUsuarios", x => new { x.Dni, x.RolPerfilId });
                    table.ForeignKey(
                        name: "FK_RolUsuarios_Usuarios_Dni",
                        column: x => x.Dni,
                        principalTable: "Usuarios",
                        principalColumn: "Dni",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RolUsuarios_RolPerfiles_RolPerfilId",
                        column: x => x.RolPerfilId,
                        principalTable: "RolPerfiles",
                        principalColumn: "RolPerfilId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Historiales_ProductoId",
                table: "Historiales",
                column: "ProductoId");

            migrationBuilder.CreateIndex(
                name: "IX_Historiales_TiendaId",
                table: "Historiales",
                column: "TiendaId");

            migrationBuilder.CreateIndex(
                name: "IX_Limites_CategoriaId",
                table: "Limites",
                column: "CategoriaId");

            migrationBuilder.CreateIndex(
                name: "IX_Productos_CategoriaId",
                table: "Productos",
                column: "CategoriaId");

            migrationBuilder.CreateIndex(
                name: "IX_RolPerfiles_PerfilId",
                table: "RolPerfiles",
                column: "PerfilId");

            migrationBuilder.CreateIndex(
                name: "IX_RolUsuarios_RolPerfilId",
                table: "RolUsuarios",
                column: "RolPerfilId");

            migrationBuilder.CreateIndex(
                name: "IX_Solicitudes_FamiliaId",
                table: "Solicitudes",
                column: "FamiliaId");

            migrationBuilder.CreateIndex(
                name: "IX_Stocks_TiendaId",
                table: "Stocks",
                column: "TiendaId");

            migrationBuilder.CreateIndex(
                name: "IX_UsuarioFamilias_FamiliaId",
                table: "UsuarioFamilias",
                column: "FamiliaId");

            migrationBuilder.CreateIndex(
                name: "IX_UsuarioTiendas_TiendaId",
                table: "UsuarioTiendas",
                column: "TiendaId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Historiales");

            migrationBuilder.DropTable(
                name: "Limites");

            migrationBuilder.DropTable(
                name: "RolUsuarios");

            migrationBuilder.DropTable(
                name: "Solicitudes");

            migrationBuilder.DropTable(
                name: "Stocks");

            migrationBuilder.DropTable(
                name: "UsuarioFamilias");

            migrationBuilder.DropTable(
                name: "UsuarioTiendas");

            migrationBuilder.DropTable(
                name: "RolPerfiles");

            migrationBuilder.DropTable(
                name: "Productos");

            migrationBuilder.DropTable(
                name: "Familias");

            migrationBuilder.DropTable(
                name: "Usuarios");

            migrationBuilder.DropTable(
                name: "Tiendas");

            migrationBuilder.DropTable(
                name: "Perfiles");

            migrationBuilder.DropTable(
                name: "Categorias");
        }
    }
}

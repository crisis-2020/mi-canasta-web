
using MiCanasta.MiCanasta.Model;
using MiCanasta.MiCanasta.Persistence;
using MiCanasta.MiCanasta.Persistence.Config;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MiCanasta.Persistence
{
    public class ApplicationDbContext: DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        public DbSet<Categoria> Categorias { get; set; }
        public DbSet<Familia> Familias { get; set; }
        public DbSet<Historial> Historiales { get; set; }
        public DbSet<Limite> Limites { get; set; }
        public DbSet<Perfil> Perfiles { get; set; }
        public DbSet<Producto> Productos { get; set; }
        public DbSet<RolPerfil> RolPerfiles { get; set; }
        public DbSet<RolUsuario> RolUsuarios { get; set; }
        public DbSet<Solicitud> Solicitudes { get; set; }
        public DbSet<Stock> Stocks { get; set; }
        public DbSet<Tienda> Tiendas { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<UsuarioFamilia> UsuarioFamilias { get; set; }
        public DbSet<UsuarioTienda> UsuarioTiendas { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            new CategoriaConfig(builder.Entity<Categoria>());
            new FamiliaConfig(builder.Entity<Familia>());
            new HistorialConfig(builder.Entity<Historial>());
            new LimiteConfig(builder.Entity<Limite>());
            new PerfilConfig(builder.Entity<Perfil>());
            new ProductoConfig(builder.Entity<Producto>());
            new RolPerfilConfig(builder.Entity<RolPerfil>());
            new RolUsuarioConfig(builder.Entity<RolUsuario>());
            new SolicitudConfig(builder.Entity<Solicitud>());
            new StockConfig(builder.Entity<Stock>());
            new TiendaConfig(builder.Entity<Tienda>());
            new UsuarioConfig(builder.Entity<Usuario>());
            new UsuarioFamiliaConfig(builder.Entity<UsuarioFamilia>());
            new UsuarioTiendaConfig(builder.Entity<UsuarioTienda>());

        }
    }
}

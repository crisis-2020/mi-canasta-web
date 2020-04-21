
using MiCanasta.MiCanasta.Model;
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

        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<UsuarioTienda> UsuarioTiendas { get; set; }
        public DbSet<UsuarioFamilia> UsuariosFamilias { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            new UsuarioConfig(builder.Entity<Usuario>());
            new UsuarioTiendaConfig(builder.Entity<UsuarioTienda>());
            new UsuarioFamiliaConfig(builder.Entity<UsuarioFamilia>());

        }
    }
}

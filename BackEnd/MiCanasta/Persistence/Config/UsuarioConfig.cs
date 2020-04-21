using MiCanasta.MiCanasta.Model;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MiCanasta.MiCanasta.Persistence.Config
{
    public class UsuarioConfig
    {
        public UsuarioConfig(EntityTypeBuilder<Usuario> entityBuilder)
        {
            entityBuilder.HasKey(x => x.Dni);
            entityBuilder.Property(x => x.Dni).IsRequired();

            entityBuilder.Property(x => x.Nombre).IsRequired();
            entityBuilder.Property(x => x.ApellidoPaterno).IsRequired();
            entityBuilder.Property(x => x.ApellidoMaterno).IsRequired();
            entityBuilder.Property(x => x.Contrasena).IsRequired();
            entityBuilder.Property(x => x.Correo).IsRequired();

        }
    }
}

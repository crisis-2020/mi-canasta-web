using AutoMapper;
using MiCanasta.MiCanasta.Dto;
using MiCanasta.MiCanasta.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MiCanasta.BackEnd.ConfigMapper
{
    public class AutoMapperConfig : Profile
    {
        public AutoMapperConfig()
        {
            //CreateMap<Product, ProductDto>();
            CreateMap<Usuario, UsuarioDto>();
            CreateMap<UsuarioTienda, UsuarioTiendaDto>();
            CreateMap<UsuarioFamilia, UsuarioFamiliaDto>();
        }
    }
}

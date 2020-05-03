using AutoMapper;
using MiCanasta.MiCanasta.Dto;
using MiCanasta.MiCanasta.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static MiCanasta.MiCanasta.Services.Impl.SolicitudServiceImpl;

namespace MiCanasta.BackEnd.ConfigMapper
{
    public class AutoMapperConfig : Profile
    {
        public AutoMapperConfig()
        {
            CreateMap<Producto, ProductoDto>();
            CreateMap<SolicitudFamiliaDni , NombreFamiliaDto>();
            //CreateMap<Product, ProductDto>();
            CreateMap<Usuario, UsuarioDto>();
            CreateMap<UsuarioReniecDto, UsuarioAccesoDto>();
            CreateMap<UsuarioDto, UsuarioAccesoDto>();

            CreateMap<Solicitud, SolicitudDto>();
        }

    }

}

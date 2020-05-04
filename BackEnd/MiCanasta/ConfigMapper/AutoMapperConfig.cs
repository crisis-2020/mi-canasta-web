using AutoMapper;
using MiCanasta.MiCanasta.Dto;
using MiCanasta.MiCanasta.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MiCanasta.MiCanasta;

using static MiCanasta.MiCanasta.Services.Impl.SolicitudServiceImpl;

namespace MiCanasta.BackEnd.ConfigMapper
{
    public class AutoMapperConfig : Profile
    {
        public AutoMapperConfig()
        {
            CreateMap<Familia, FamiliaCreateDto>();
            CreateMap<Producto, ProductoDto>();
            CreateMap<SolicitudFamiliaDni , NombreFamiliaDto>();
            CreateMap<Usuario, UsuarioDto>();
            CreateMap<UsuarioReniecDto, UsuarioAccesoDto>();
            CreateMap<UsuarioDto, UsuarioAccesoDto>();
            CreateMap<Solicitud, SolicitudDto>();
        }

    }

}


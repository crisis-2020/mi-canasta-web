using AutoMapper;
using MiCanasta.Micanasta.Dto;
using MiCanasta.MiCanasta.Dto;
using MiCanasta.MiCanasta.Model;
using MiCanasta.MiCanasta;

using static MiCanasta.MiCanasta.Services.Impl.SolicitudServiceImpl;
using MiCanasta.Dto;

namespace MiCanasta.BackEnd.ConfigMapper
{
    public class AutoMapperConfig : Profile
    {
        public AutoMapperConfig()
        {
            CreateMap<Familia, FamiliaCreateDto>();
            CreateMap<Familia, FamiliaDto>();
            CreateMap<Producto, ProductoDto>();
            CreateMap<Perfil, PerfilDto>();
            CreateMap<Usuario, UsuarioDto>();
            CreateMap<UsuarioReniecDto, UsuarioAccesoDto>();
            CreateMap<UsuarioDto, UsuarioAccesoDto>();
            CreateMap<UsuarioFamilia, UsuarioFamiliaDto>();
            CreateMap<Historial, HistorialDto>();
            CreateMap<RolUsuario, RolUsuarioDto>();
            CreateMap<RolPerfil, RolPerfilDto>();
            CreateMap<Solicitud, SolicitudDto>();
            CreateMap<SolicitudFamiliaDni, SolicitudBusquedaDto>();
            CreateMap<SolicitudUsuarioDto, Solicitud>();
            CreateMap<SolicitudUsuarioDto, UsuarioFamilia>();
            CreateMap<Tienda, TiendaDto>();
        }

    }

}


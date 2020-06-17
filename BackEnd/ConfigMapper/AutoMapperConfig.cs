using AutoMapper;
using MiCanasta.Micanasta.Dto;
using MiCanasta.MiCanasta.Dto;
using MiCanasta.MiCanasta.Model;
using MiCanasta.MiCanasta;

using static MiCanasta.MiCanasta.Services.Impl.SolicitudServiceImpl;
using MiCanasta.Dto;
using System.Collections.Generic;

namespace MiCanasta.BackEnd.ConfigMapper
{
    public class AutoMapperConfig : Profile
    {
        public AutoMapperConfig()
        {
            CreateMap<Categoria, CategoriaDto>();
            CreateMap<Familia, FamiliaCreateDto>();
            CreateMap<Familia, FamiliaDto>();
            CreateMap<Limite, LimiteDto>();
            CreateMap<Producto, ProductoDto>();
            CreateMap<Perfil, PerfilDto>();
            CreateMap<Usuario, UsuarioDto>();
            CreateMap<UsuarioReniecDto, UsuarioAccesoDto>();
            CreateMap<UsuarioDto, UsuarioAccesoDto>();
            CreateMap<UsuarioFamilia, UsuarioFamiliaDto>();
            CreateMap<Compra, CompraDto>();
            CreateMap<RolUsuario, RolUsuarioDto>();
            CreateMap<RolPerfil, RolPerfilDto>();
            CreateMap<Solicitud, SolicitudDto>();
            CreateMap<SolicitudFamiliaDni, SolicitudBusquedaDto>();
            CreateMap<SolicitudUsuarioDto, Solicitud>();
            CreateMap<SolicitudUsuarioDto, UsuarioFamilia>();
            CreateMap<Stock, StockDto>();
            CreateMap<Tienda, TiendaDto>();
            CreateMap<Familia, FamiliaDataDto>();
            CreateMap<Tienda, TiendaDataDto>();
            CreateMap<RolUsuario, RolUsuarioDataDto>();
            CreateMap<UsuarioFamilia, UsuarioFamiliaGetDto>();
            CreateMap<Compra, CompraDto>();
            CreateMap<CompraCreateDto, Compra>();
            CreateMap<CompraUpdateDto, Compra>();
            CreateMap<Stock, StockRequestDto>();
            CreateMap<Solicitud, SolicitudGetDto>();

        }

    }

}


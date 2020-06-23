using AutoMapper;
using MiCanasta.MiCanasta.Dto;
using MiCanasta.MiCanasta.Exceptions;
using MiCanasta.MiCanasta.Model;
using MiCanasta.Persistence;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MiCanasta.MiCanasta.Services.Impl
{
    public class SolicitudServiceImpl: SolicitudService
    {   
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;

        public SolicitudServiceImpl(ApplicationDbContext context,
            IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public List<SolicitudDto> GetAll()
        {
            return _mapper.Map<List<SolicitudDto>>(
                             _context.Solicitudes.Include(x=>x.Familia)
                                            .OrderBy(x => x.Dni)
                                          .AsQueryable()
                                          .ToList());
        }

        public SolicitudDto GetById(string dni, string familiaNombre)
        {

            return _mapper.Map<SolicitudDto>(
                 _context.Solicitudes.Include(x=>x.Familia)
                                    .Single(x => (x.Dni == dni && x.Familia.Nombre == familiaNombre))
            ) ;
        }

        public bool AceptaSolicitudes(SolicitudCreateDto model) {
            if (_context.Familias.Single(x => x.Nombre == model.FamiliaNombre).AceptaSolicitudes == true)
                return true;
            else return false;
        }

        public SolicitudDto Create(SolicitudCreateDto model)
        {
            Solicitud entry = null;

            if (_context.Familias.SingleOrDefault(x => x.Nombre == model.FamiliaNombre) == null) throw new FamilyNotFoundException();

            else
            {
                if (AceptaSolicitudes(model) == false) throw new FamilyNotAceptedSolicitudeException();
                else
                {
                    var familia = _context.Familias.Single(x => x.Nombre == model.FamiliaNombre);

                    entry = new Solicitud
                    {
                        FamiliaId = familia.FamiliaId,
                        Dni = model.Dni,
                    };

                    _context.Add(entry);
                    _context.SaveChanges();
                }
            }
            return _mapper.Map<SolicitudDto>(entry);
        }
            


        public SolicitudBusquedaDto ObtenerNombreFamilia(String Dni)
        {

            var solicitud = _context.Solicitudes.SingleOrDefault(x => x.Dni == Dni);
            if (solicitud == null) return null;         
         
            var familia =  _context.Familias.Single(x => x.FamiliaId == solicitud.FamiliaId);

            SolicitudBusquedaDto entry = new SolicitudBusquedaDto
            {
                Dni = Dni,
                NombreFamilia = familia.Nombre,
            };
         
            return entry;

        }

        public bool BorrarSolicitud(SolicitudUsuarioDto solicitudDto)
        {
            try
            {
                Solicitud solicitud = _mapper.Map<Solicitud>(solicitudDto);
                _context.Solicitudes.Remove(solicitud);
                _context.SaveChanges();
                return true;
            }catch (Exception)
            {
                return false;
            }
        }
        public List<SolicitudGetDto> GetSolicitudesByFamiliaId(int? FamiliaId) 
        {
            List<Solicitud> solicitudes = _context.Solicitudes.Where(x => x.FamiliaId == FamiliaId).AsQueryable().ToList();
            List<SolicitudGetDto> solicitudGetDtos = _mapper.Map<List<SolicitudGetDto>>(solicitudes);
            return solicitudGetDtos;
        }

    }
}

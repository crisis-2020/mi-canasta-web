using AutoMapper;
using MiCanasta.MiCanasta.Dto;
using MiCanasta.MiCanasta.Model;
using MiCanasta.Persistence;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace MiCanasta.MiCanasta.Services.Impl
{
    public class HistorialServiceImpl: HistorialService
    {

        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;

        public HistorialServiceImpl(ApplicationDbContext context,
            IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public HistorialCreateDto Create(HistorialCreateDto HistorialCreateDto)
        {
            _context.Add(_mapper.Map<Historial>(HistorialCreateDto));
            _context.SaveChanges();
            return HistorialCreateDto;
        }

        public List<HistorialDto> GetHistorial(int FamiliaId, string Dni, DateTime FechaInicio, DateTime FechaFinal)
        {
            List<HistorialDto> Historiales = _mapper.Map<List<HistorialDto>>(_context.Historiales.Where(x => x.Dni == Dni && x.Familia.FamiliaId == FamiliaId && FechaInicio <= x.FechaCompra && x.FechaCompra <= FechaFinal).OrderBy(x => x.FechaCompra).AsQueryable().ToList());
            if (Historiales.Count() == 0) throw new Exception();
                return Historiales;
        }

        public HistorialUpdateDto Update(HistorialUpdateDto HistorialDto)
        {
            Historial _historial = _context.Historiales.SingleOrDefault(x => x.FamiliaId == HistorialDto.FamiliaId && x.TiendaId == HistorialDto.TiendaId && x.ProductoId == HistorialDto.ProductoId);
            if (_historial != null)
            {
                _historial.Dni = HistorialDto.Dni;
                _historial.Cantidad = HistorialDto.Cantidad;
                _historial.Confirmacion = HistorialDto.Confirmacion;
                _historial.FechaCompra = HistorialDto.FechaCompra;
                _context.SaveChanges();
            }
            else throw new Exception();
            return HistorialDto;

        }
    }
}

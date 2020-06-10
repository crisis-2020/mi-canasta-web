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
    public class CompraServiceImpl: CompraService
    {

        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;

        public CompraServiceImpl(ApplicationDbContext context,
            IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public CompraCreateDto Create(CompraCreateDto CompraCreateDto)
        {
            _context.Add(_mapper.Map<Compra>(CompraCreateDto));
            _context.SaveChanges();
            return CompraCreateDto;
        }

        public List<CompraDto> GetCompra(int FamiliaId, string Dni, DateTime FechaInicio, DateTime FechaFinal)
        {
            List<CompraDto> Compras = _mapper.Map<List<CompraDto>>(_context.Compras.Where(x => x.Dni == Dni && x.Familia.FamiliaId == FamiliaId && FechaInicio <= x.FechaCompra && x.FechaCompra <= FechaFinal).OrderBy(x => x.FechaCompra).AsQueryable().ToList());
            if (Compras.Count() == 0) throw new Exception();
                return Compras;
        }

        public CompraUpdateDto Update(CompraUpdateDto CompraDto)
        {
            Compra _compra = _context.Compras.SingleOrDefault(x => x.FamiliaId == CompraDto.FamiliaId && x.TiendaId == CompraDto.TiendaId && x.ProductoId == CompraDto.ProductoId);
            if (_compra != null)
            {
                _compra.Dni = CompraDto.Dni;
                _compra.Cantidad = CompraDto.Cantidad;
                _compra.Confirmacion = CompraDto.Confirmacion;
                _compra.FechaCompra = CompraDto.FechaCompra;
                _context.SaveChanges();
            }
            else throw new Exception();
            return CompraDto;

        }
    }
}

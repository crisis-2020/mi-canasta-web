using AutoMapper;
using MiCanasta.MiCanasta.Dto;
using MiCanasta.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MiCanasta.MiCanasta.Services.Impl
{
    public class UsuarioFamiliaServiceImpl : UsuarioFamiliaService
    {

        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;

        public UsuarioFamiliaServiceImpl(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public UsuarioFamiliaDto Create(UsuarioFamiliaCreateDto model)
        {
            throw new NotImplementedException();
        }

        public List<UsuarioFamiliaDto> GetAll()
        {
            throw new NotImplementedException();
        }

        public UsuarioFamiliaDto GetById(int id)
        {
            throw new NotImplementedException();
        }

        public void Remove(int id)
        {
            throw new NotImplementedException();
        }

        public void Update(int id, UsuarioFamiliaUpdateDto model)
        {
            throw new NotImplementedException();
        }
    }
}

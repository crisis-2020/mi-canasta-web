using AutoMapper;
using MiCanasta.MiCanasta.Exceptions;
using MiCanasta.MiCanasta.Model;
using MiCanasta.Persistence;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace MiCanasta.MiCanasta.Services.Impl
{
    public class FamiliaServiceImpl : FamiliaService
    {

        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;

        public FamiliaServiceImpl(ApplicationDbContext context,
            IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public FamiliaCreateDto Create(FamiliaCreateDto model)
        {
            if (_context.Familias.SingleOrDefault(x => x.Nombre == model.FamiliaNombre) == null)
            {

                var entry = new Familia
                {
                    Nombre = model.FamiliaNombre,
                    Dni = model.Dni,
                    AceptaSolicitudes = true,
                };
                _context.Add(entry);
                _context.SaveChanges();
                return _mapper.Map<FamiliaCreateDto>(entry);
            }
            else // grupo familiar ya existe
            {
                return null;
            }
        }

        public FamiliaDto GetByFamiliaNombre(string familiaNombre) {

            FamiliaDto result = null;
            var familia = _context.Familias
                .Include(x => x.UsuarioFamilias)
                .ThenInclude(x => x.Usuario)
                .ThenInclude(x => x.RolUsuarios)
                .ThenInclude(x => x.RolPerfil)
                .ThenInclude(x => x.Perfil)
                .SingleOrDefault(x => x.Nombre == familiaNombre);

            if (familia == null) throw new FamilyNotFoundException();
            else {
                result = _mapper.Map<FamiliaDto>(familia);
                result.Nombre = familiaNombre;
            }
            return result;

        }
    }
}
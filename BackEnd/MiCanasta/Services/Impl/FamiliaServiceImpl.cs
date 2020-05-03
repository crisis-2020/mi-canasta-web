using AutoMapper;
using MiCanasta.MiCanasta.Model;
using MiCanasta.Persistence;
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
    }
}
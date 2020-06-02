using AutoMapper;
using MiCanasta.MiCanasta.Dto;
using MiCanasta.MiCanasta.Model;
using MiCanasta.Persistence;

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
    }
}

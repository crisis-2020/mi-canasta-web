using MiCanasta.MiCanasta.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MiCanasta.MiCanasta.Services
{
    public interface UsuarioTiendaService
    {
        List<UsuarioTiendaDto> GetAll();
        UsuarioTiendaDto GetById(int id);
        UsuarioTiendaDto Create(UsuarioTiendaCreateDto model);
        void Update(int id, UsuarioTiendaUpdateDto model);
        void Remove(int id);
    }
}

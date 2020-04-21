using MiCanasta.MiCanasta.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MiCanasta.MiCanasta.Services
{
    public interface UsuarioFamiliaService
    {
        List<UsuarioFamiliaDto> GetAll();
        UsuarioFamiliaDto GetById(int id);
        UsuarioFamiliaDto Create(UsuarioFamiliaCreateDto model);
        void Update(int id, UsuarioFamiliaUpdateDto model);
        void Remove(int id);
    }
}

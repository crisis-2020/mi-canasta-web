using MiCanasta.Dto;
using MiCanasta.Micanasta.Dto;
using MiCanasta.MiCanasta.Dto;
using MiCanasta.MiCanasta.Model;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MiCanasta.MiCanasta.Services
{
    public interface FamiliaService 
    {
        public List<ListarUsuarioFamiliaDto> GetByFamiliaNombre(string familiaNombre);
        public FamiliaCreateDto Create(FamiliaCreateDto model);
        public void DesactivarSolicitudes(int FamiliaId);
        public UsuarioFamiliaDto Remove(string UserDni);
        public List<CompraDto> GetCompra(string FamiliaNombre, DateTime Inicio, DateTime Fin);
        public FamiliaDataDto GetById(int FamiliaId);
    }        
}
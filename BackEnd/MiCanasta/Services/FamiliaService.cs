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
        public List<UsuarioDto> GetByFamiliaNombre(string familiaNombre);
        public FamiliaCreateDto Create(FamiliaCreateDto model);
        public Familia DesactivarSolicitudes(string nombreFamilia, string Dni);
        public UsuarioFamiliaDto Remove(string UserDni);
        public List<HistorialDto> GetHistorial(string FamiliaNombre, DateTime Inicio, DateTime Fin);
    }        
}
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
        public FamiliaDto GetByFamiliaNombre(string familiaNombre);
        public FamiliaCreateDto Create(FamiliaCreateDto model);
        public Familia DesactivarSolicitudes(string nombreFamilia, string Dni);
        public UsuarioFamiliaDto Remove(string AdminDni, string UserDni);
        public UsuarioFamiliaDto RemoveMyself(string NombreFamilia, string Dni);
        public List<HistorialDto> GetHistorial(string FamiliaNombre, DateTime Inicio, DateTime Fin);
    }        
}
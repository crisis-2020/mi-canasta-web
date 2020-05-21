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
    }        
}